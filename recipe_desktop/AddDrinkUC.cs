using entity_classes;
using exceptions;
using manager_classes;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class AddDrinkUC : UserControl
    {
        private readonly DesktopUser user;
        private readonly IRecipeManager recipeManager;
        private readonly IIngredientManager ingredientManager;
        private RecipePic uploadedPic;

        public AddDrinkUC(DesktopUser user, IRecipeManager recipeManager, IIngredientManager ingredientManager)
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

            rtbDescription.TextChanged += new EventHandler(rtbDescription_TextChanged);
            rtbInstructions.TextChanged += new EventHandler(rtbInstructions_TextChanged);
        }

        private void LoadDifficulty()
        {
            var difficulties = recipeManager.GetAllDifficulties();
            cbDifficulty.Items.Clear();

            foreach (var difficulty in difficulties)
            {
                cbDifficulty.Items.Add(difficulty.GetName());
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
                cbDietRestriction.Items.Add(dietRestriction.GetName());
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
                ingredientUC.IngredientAdded += new EventHandler<IngredientRecipe>(IngredientUC_IngredientAdded);
                ingredientUC.Margin = new Padding(0, 0, 0, 10);
                flowPanel.Controls.Add(ingredientUC);
            }

            panelLoadIngredients.Controls.Add(flowPanel);
        }

        private void IngredientUC_IngredientAdded(object sender, IngredientRecipe e)
        {
            lbAddedIngredients.Items.Add(e);
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
                    ingredientUC.IngredientAdded += new EventHandler<IngredientRecipe>(IngredientUC_IngredientAdded);
                    ingredientUC.Margin = new Padding(0, 0, 0, 10);
                    flowPanel.Controls.Add(ingredientUC);
                    found = true;
                }
            }

            lblNoResults.Visible = !found;
            panelLoadIngredients.Controls.Add(flowPanel);
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string title = tbTitle.Text.Trim();
                string description = rtbDescription.Text.Trim();
                string instructions = rtbInstructions.Text.Trim();
                DietRestriction diet = recipeManager.GetDietByName(cbDietRestriction.SelectedItem.ToString());
                Difficulty difficulty = recipeManager.GetDifficultyByName(cbDifficulty.SelectedItem.ToString());
                decimal prepTime = Convert.ToDecimal(tbPrepTime.Text.Trim());
                decimal cookingTime = Convert.ToDecimal(tbCookingTime.Text.Trim());
                bool isAlcoholic = cbAlcohol.Checked;
                bool containsCaffeine = cbContainsCaffeine.Checked;
                bool servedHot = cbServedHot.Checked;
                int pours = Convert.ToInt32(tbPours.Text.Trim());

                List<IngredientRecipe> ingredients = new List<IngredientRecipe>();
                foreach (IngredientRecipe item in lbAddedIngredients.Items)
                {
                    ingredients.Add(item);
                }

                Drink drink = new Drink(0, title, description, instructions, ingredients, user,
                    TimeSpan.FromMinutes((double)prepTime), TimeSpan.FromMinutes((double)cookingTime), diet, difficulty, 
                    uploadedPic, isAlcoholic, containsCaffeine, servedHot, pours);

                recipeManager.UploadDrink(drink);
                MessageBox.Show("Recipe uploaded successfully!");
            }
            catch (InvalidRecipeException ex)
            {
                MessageBox.Show($"Error uploading recipe: {ex.Message}");
            }
        }
    }
}
