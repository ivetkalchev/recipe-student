using entity_classes;
using manager_classes;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private int totalRecipesCount;
        private string searchTerm;
        private string sortOption = "Title";

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
            totalRecipesCount = recipeManager.GetTotalRecipesCount(searchTerm);
            recipes = recipeManager.GetPagedRecipes(currentPage, RecipesPerPage, searchTerm, sortOption);
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
                foreach (var recipe in recipesToDisplay)
                {
                    SingleRecipeUC recipeUC = new SingleRecipeUC(recipeManager, ingredientManager, recipe);
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

        private void UpdatePaginationButtons()
        {
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < (totalRecipesCount + RecipesPerPage - 1) / RecipesPerPage;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadAllRecipes();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < (totalRecipesCount + RecipesPerPage - 1) / RecipesPerPage)
            {
                currentPage++;
                LoadAllRecipes();
            }
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            searchTerm = tbSearch.Text.Trim().ToLower();
            currentPage = 1;
            LoadAllRecipes();
        }

        private void btnAddRecipes_Click(object sender, EventArgs e)
        {
            AddRecipeForm addRecipe = new AddRecipeForm(user, recipeManager, ingredientManager);
            addRecipe.Show();
        }
    }
}
