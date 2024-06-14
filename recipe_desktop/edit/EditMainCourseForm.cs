using entity_classes;
using manager_classes;

namespace recipe_desktop
{
    public partial class EditMainCourseForm : Form
    {
        private IRecipeManager recipeManager;
        private MainCourse mainCourse;
        private IIngredientManager ingredientManager;

        public EditMainCourseForm(MainCourse mainCourse, IRecipeManager recipeManager, IIngredientManager ingredientManager)
        {
            InitializeComponent();
            this.mainCourse = mainCourse;
            this.recipeManager = recipeManager;
            this.ingredientManager = ingredientManager;

            LoadRecipeDetails();
            LoadIngredients();
            LoadDifficulties();
            LoadDietRestrictions();
            LoadCurrentIngredients();
            LockFields();
        }

        private void LoadRecipeDetails()
        {
            tbTitle.Text = mainCourse.GetTitle();
            rtbDescription.Text = mainCourse.GetDescription();
            rtbInstructions.Text = mainCourse.GetInstructions();
            tbPrepTime.Text = mainCourse.GetPreparationTime().TotalMinutes.ToString();
            tbCookingTime.Text = mainCourse.GetCookingTime().TotalMinutes.ToString();
            cbSpicy.Checked = mainCourse.GetIsSpicy();
            tbServings.Text = mainCourse.GetServings().ToString();
        }

        private void LoadIngredients()
        {
            panelLoadIngredients.Controls.Clear();
            lblNoResults.Visible = false;

            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            List<Ingredient> ingredients = ingredientManager.GetAllIngredients();
            foreach (var ingredient in ingredients)
            {
                var ingredientUC = new SingleIngredientRecipeUC(ingredient, ingredientManager);
                ingredientUC.IngredientAdded += IngredientUC_IngredientAdded;
                ingredientUC.Margin = new Padding(0, 0, 0, 10);
                flowPanel.Controls.Add(ingredientUC);
            }

            panelLoadIngredients.Controls.Add(flowPanel);
        }

        private void IngredientUC_IngredientAdded(object sender, IngredientRecipe e)
        {
            lbAddedIngredients.Items.Add(e);
            recipeManager.InsertIngredientToRecipe(mainCourse.GetIdRecipe(), e.GetIngredient().GetId(), e.GetUnit().GetId(), e.GetQuantity());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbAddedIngredients.SelectedItem != null)
            {
                if (lbAddedIngredients.SelectedItem is IngredientRecipe ingredientRecipe)
                {
                    recipeManager.DeleteIngredientFromRecipe(mainCourse.GetIdRecipe(), ingredientRecipe.GetIngredient().GetId());
                    lbAddedIngredients.Items.Remove(lbAddedIngredients.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Selected item is not a valid ingredient.");
                }
            }
            else
            {
                MessageBox.Show("Please select an ingredient to delete.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadDifficulties()
        {
            var difficulties = recipeManager.GetAllDifficulties();
            cbDifficulty.Items.Clear();

            foreach (var difficulty in difficulties)
            {
                cbDifficulty.Items.Add(difficulty.GetName());
            }

            var selectedDifficulty = mainCourse.GetDifficulty().GetName();
            cbDifficulty.SelectedIndex = cbDifficulty.Items.IndexOf(selectedDifficulty);
        }

        private void LoadDietRestrictions()
        {
            var diets = recipeManager.GetAllDietRestrictions();
            cbDietRestriction.Items.Clear();

            foreach (var diet in diets)
            {
                cbDietRestriction.Items.Add(diet.GetName());
            }

            var selectedDiet = mainCourse.GetDietRestriction().GetName();
            cbDietRestriction.SelectedIndex = cbDietRestriction.Items.IndexOf(selectedDiet);
        }

        private void LoadCurrentIngredients()
        {
            lbAddedIngredients.Items.Clear();
            var ingredientRecipes = ingredientManager.GetIngredientsForRecipe(mainCourse.GetIdRecipe());
            foreach (var ingredientRecipe in ingredientRecipes)
            {
                lbAddedIngredients.Items.Add(ingredientRecipe);
            }
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = tbSearchIng.Text.Trim().ToLower();
            panelLoadIngredients.Controls.Clear();

            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            List<Ingredient> ingredients = ingredientManager.GetAllIngredients();
            bool found = false;
            foreach (var ingredient in ingredients)
            {
                if (ingredient.GetName().ToLower().Contains(searchTerm))
                {
                    var ingredientUC = new SingleIngredientRecipeUC(ingredient, ingredientManager);
                    ingredientUC.IngredientAdded += IngredientUC_IngredientAdded;
                    ingredientUC.Margin = new Padding(0, 0, 0, 10);
                    flowPanel.Controls.Add(ingredientUC);
                    found = true;
                }
            }

            lblNoResults.Visible = !found;
            panelLoadIngredients.Controls.Add(flowPanel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string title = tbTitle.Text.Trim();
                string description = rtbDescription.Text.Trim();
                string instructions = rtbInstructions.Text.Trim();
                string prepTimeText = tbPrepTime.Text.Trim();
                string cookingTimeText = tbCookingTime.Text.Trim();
                bool isSpicy = cbSpicy.Checked;
                string servingsText = tbServings.Text.Trim();

                if (string.IsNullOrWhiteSpace(title) ||
                    string.IsNullOrWhiteSpace(description) ||
                    string.IsNullOrWhiteSpace(instructions) ||
                    cbDietRestriction.SelectedItem == null ||
                    cbDifficulty.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(prepTimeText) ||
                    string.IsNullOrWhiteSpace(cookingTimeText) ||
                    string.IsNullOrWhiteSpace(servingsText))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                decimal.TryParse(prepTimeText, out decimal prepTime);
                decimal.TryParse(cookingTimeText, out decimal cookingTime);
                int.TryParse(servingsText, out int servings);

                DietRestriction diet = recipeManager.GetDietByName(cbDietRestriction.SelectedItem.ToString());
                Difficulty difficulty = recipeManager.GetDifficultyByName(cbDifficulty.SelectedItem.ToString());

                List<IngredientRecipe> ingredientRecipes = new List<IngredientRecipe>();
                foreach (var item in lbAddedIngredients.Items)
                {
                    if (item is IngredientRecipe ingredientRecipe)
                    {
                        ingredientRecipes.Add(ingredientRecipe);
                    }
                }

                var updatedMainCourse = new MainCourse(
                    mainCourse.GetIdRecipe(),
                    title,
                    description,
                    instructions,
                    ingredientRecipes,
                    (DesktopUser)mainCourse.GetUser(),
                    TimeSpan.FromMinutes((double)prepTime),
                    TimeSpan.FromMinutes((double)cookingTime),
                    diet,
                    difficulty,
                    mainCourse.GetRecipePic(),
                    isSpicy,
                    servings
                );

                updatedMainCourse.RecipeValidation();
                updatedMainCourse.FoodValidation();

                recipeManager.UpdateMainCourse(updatedMainCourse);
                MessageBox.Show("Recipe updated successfully!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating recipe: {ex.Message}");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UnlockFields();
        }

        private void LockFields()
        {
            tbTitle.ReadOnly = true;
            rtbDescription.ReadOnly = true;
            rtbInstructions.ReadOnly = true;
            tbPrepTime.ReadOnly = true;
            tbCookingTime.ReadOnly = true;
            cbSpicy.Enabled = false;
            tbServings.ReadOnly = true;
            cbDifficulty.Enabled = false;
            cbDietRestriction.Enabled = false;
            lbAddedIngredients.Enabled = false;
        }

        private void UnlockFields()
        {
            tbTitle.ReadOnly = false;
            rtbDescription.ReadOnly = false;
            rtbInstructions.ReadOnly = false;
            tbPrepTime.ReadOnly = false;
            tbCookingTime.ReadOnly = false;
            cbSpicy.Enabled = true;
            tbServings.ReadOnly = false;
            cbDifficulty.Enabled = true;
            cbDietRestriction.Enabled = true;
            lbAddedIngredients.Enabled = true;
        }

        private void tbPrepTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Please enter only numeric values for time.");
                e.Handled = true;
            }
        }

        private void tbCookingTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Please enter only numeric values for time.");
                e.Handled = true;
            }
        }
    }
}