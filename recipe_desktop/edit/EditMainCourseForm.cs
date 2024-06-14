using entity_classes;
using manager_classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
                    tbTitle.Text,
                    rtbDescription.Text,
                    rtbInstructions.Text,
                    ingredientRecipes,
                    (DesktopUser)mainCourse.GetUser(),
                    TimeSpan.FromMinutes(Convert.ToDouble(tbPrepTime.Text)),
                    TimeSpan.FromMinutes(Convert.ToDouble(tbCookingTime.Text)),
                    recipeManager.GetDietByName(cbDietRestriction.SelectedItem.ToString()),
                    recipeManager.GetDifficultyByName(cbDifficulty.SelectedItem.ToString()),
                    mainCourse.GetRecipePic(),
                    cbSpicy.Checked,
                    Convert.ToInt32(tbServings.Text)
                );

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
    }
}