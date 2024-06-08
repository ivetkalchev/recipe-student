using entity_classes;
using manager_classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class RecipesUC : UserControl
    {
        private DesktopUser user;
        private IRecipeManager recipeManager;
        private IIngredientManager ingredientManager;

        private List<Recipe> recipes;
        private List<Recipe> searchResults;

        private int currentPage;
        private const int RecipesPerPage = 5;

        public RecipesUC(DesktopUser user, IRecipeManager recipeManager, IIngredientManager ingredientManager)
        {
            InitializeComponent();

            this.user = user;
            this.recipeManager = recipeManager;
            this.ingredientManager = ingredientManager;

            currentPage = 1;

            LoadAllRecipes();
        }

        private void LoadAllRecipes()
        {
            recipes = recipeManager.GetAllRecipes();
            UpdatePagination();
            DisplayRecipes();
        }

        private void DisplayRecipes()
        {
            panelRecipes.Controls.Clear();
            lblNoResults.Visible = false;

            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(5)
            };

            List<Recipe> recipesToDisplay = searchResults ?? recipes;

            if (recipesToDisplay.Count == 0)
            {
                lblNoResults.Visible = true;
            }
            else
            {
                int startIndex = (currentPage - 1) * RecipesPerPage;
                int endIndex = Math.Min(startIndex + RecipesPerPage, recipesToDisplay.Count);

                for (int i = startIndex; i < endIndex; i++)
                {
                    SingleRecipeUC recipeUC = new SingleRecipeUC(recipeManager, recipesToDisplay[i]);
                    recipeUC.Margin = new Padding(5);
                    recipeUC.RecipeDeleted += new EventHandler(RecipeUC_RecipeDeleted);
                    flowPanel.Controls.Add(recipeUC);
                }

                panelRecipes.Controls.Add(flowPanel);
            }

            UpdatePaginationButtons();
        }

        private void RecipeUC_RecipeDeleted(object sender, EventArgs e)
        {
            LoadAllRecipes();
        }

        private void UpdatePagination()
        {
            currentPage = 1;
            UpdatePaginationButtons();
        }

        private void UpdatePaginationButtons()
        {
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < (searchResults?.Count ?? recipes.Count + RecipesPerPage - 1) / RecipesPerPage;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayRecipes();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < (searchResults?.Count ?? recipes.Count + RecipesPerPage - 1) / RecipesPerPage)
            {
                currentPage++;
                DisplayRecipes();
            }
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = tbSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                searchResults = null;
            }
            else
            {
                searchResults = new List<Recipe>();
                foreach (var recipe in recipes)
                {
                    if (recipe.GetTitle().ToLower().Contains(searchTerm))
                    {
                        searchResults.Add(recipe);
                    }
                }
            }

            currentPage = 1;
            DisplayRecipes();
        }

        private void btnAddRecipes_Click(object sender, EventArgs e)
        {
            AddRecipeForm addRecipe = new AddRecipeForm(user, recipeManager, ingredientManager);
            addRecipe.Show();
        }
    }
}
