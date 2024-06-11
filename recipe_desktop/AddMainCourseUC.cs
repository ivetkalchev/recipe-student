using entity_classes;
using manager_classes;

namespace recipe_desktop
{
    public partial class AddMainCourseUC : UserControl
    {
        private DesktopUser user;
        private IRecipeManager recipeManager;
        private IIngredientManager ingredientManager;
        private RecipePic uploadedPic;

        public AddMainCourseUC(DesktopUser user, IRecipeManager recipeManager, IIngredientManager ingredientManager)
        {
            InitializeComponent();

            this.user = user;
            this.recipeManager = recipeManager;
            this.ingredientManager = ingredientManager;

            LoadDifficulty();
            LoadDietRestrictions();
            LoadIngredients();

            UpdateDescriptionCharacterCount();
            UpdateInstructionsCharacterCount();

            rtbDescription.TextChanged += rtbDescription_TextChanged;
            rtbInstructions.TextChanged += rtbInstructions_TextChanged;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbAddedIngredients.SelectedItem != null)
            {
                lbAddedIngredients.Items.Remove(lbAddedIngredients.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select an ingredient to delete.");
            }
        }

        private void LoadDifficulty()
        {
            var difficulties = recipeManager.GetAllDifficulties();
            cbDifficulty.Items.Clear();

            foreach (var difficulty in difficulties)
            {
                cbDifficulty.Items.Add(difficulty.NameDifficulty);
            }
            if (cbDifficulty.Items.Count > 0)
            {
                cbDifficulty.SelectedIndex = 0;
            }
        }

        private void LoadDietRestrictions()
        {
            var dietRestrictions = recipeManager.GetAllDietRestrictions();
            cbDietRestriction.Items.Clear();

            foreach (var dietRestriction in dietRestrictions)
            {
                cbDietRestriction.Items.Add(dietRestriction.NameDietRestriction);
            }
            if (cbDietRestriction.Items.Count > 0)
            {
                cbDietRestriction.SelectedIndex = 0;
            }
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
                if (ingredient.NameIngredient.ToLower().Contains(searchTerm))
                {
                    var ingredientUC = new SingleIngredientRecipeUC(ingredient, ingredientManager);
                    ingredientUC.IngredientAdded += IngredientUC_IngredientAdded;
                    ingredientUC.Margin = new Padding(0, 0, 0, 10);
                    flowPanel.Controls.Add(ingredientUC);
                    found = true;
                }
            }

            if (!found)
            {
                lblNoResults.Visible = true;
            }
            else
            {
                lblNoResults.Visible = false;
            }

            panelLoadIngredients.Controls.Add(flowPanel);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text.Trim();
            string description = rtbDescription.Text.Trim();
            string instructions = rtbInstructions.Text.Trim();
            DietRestriction diet = recipeManager.GetDietByName(cbDietRestriction.SelectedItem.ToString());
            Difficulty difficulty = recipeManager.GetDifficultyByName(cbDifficulty.SelectedItem.ToString());
            decimal prepTime = Convert.ToDecimal(tbPrepTime.Text.Trim());
            decimal cookingTime = Convert.ToDecimal(tbCookingTime.Text.Trim());
            bool isSpicy = cbSpicy.Checked;
            int servings = Convert.ToInt32(tbServings.Text.Trim());

            List<IngredientRecipe> ingredients = new List<IngredientRecipe>();
            foreach (IngredientRecipe item in lbAddedIngredients.Items)
            {
                ingredients.Add(item);
            }

            MainCourse mainCourse = new MainCourse(0, title, description, instructions, ingredients, user,
                TimeSpan.FromMinutes((double)prepTime), TimeSpan.FromMinutes((double)cookingTime), diet, difficulty, uploadedPic, isSpicy, servings);

            recipeManager.UploadMainCourse(mainCourse);
            MessageBox.Show("Recipe uploaded successfully!");
        }

        private void btnUploadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                string fileName = Path.GetFileName(filePath);
                byte[] fileData = File.ReadAllBytes(filePath);
                string base64Data = Convert.ToBase64String(fileData);
                string contentType = GetContentType(filePath);

                uploadedPic = new RecipePic(0, fileName, base64Data, contentType);
                MessageBox.Show("Picture uploaded successfully!");
            }
        }

        private string GetContentType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                default:
                    throw new NotSupportedException("File type not supported.");
            }
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateDescriptionCharacterCount();
        }

        private void rtbInstructions_TextChanged(object sender, EventArgs e)
        {
            UpdateInstructionsCharacterCount();
        }

        private void UpdateDescriptionCharacterCount()
        {
            int currentLength = rtbDescription.Text.Length;
            lblMaxDescr.Text = $"Description: {currentLength}/400";
        }

        private void UpdateInstructionsCharacterCount()
        {
            int currentLength = rtbInstructions.Text.Length;
            lblMaxInstr.Text = $"Instructions: {currentLength}/4000";
        }
    }
}