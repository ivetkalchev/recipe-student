using entity_classes;
using manager_classes;

namespace recipe_desktop
{
    public partial class RecipesUC : UserControl
    {
        private DesktopUser user;
        private IRecipeManager recipeManager;
        private IIngredientManager ingredientManager;
        public RecipesUC(DesktopUser user, IRecipeManager recipeManager, IIngredientManager ingredientManager)
        {
            InitializeComponent();

            this.user = user;
            this.recipeManager = recipeManager;
            this.ingredientManager = ingredientManager;
        }

        private void btnAddRecipes_Click(object sender, EventArgs e)
        {
            AddRecipeForm addRecipe = new AddRecipeForm(user, recipeManager, ingredientManager);
            addRecipe.Show();
        }
    }
}
