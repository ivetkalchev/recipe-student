using Microsoft.AspNetCore.Mvc.RazorPages;
using entity_classes;
using db_helpers;
using manager_classes;

namespace recipe_web.Pages
{
    public class RecipesModel : PageModel
    {
        private IRecipeManager recipeManager;

        public List<Recipe> Recipes { get; set; }

        public RecipesModel(IRecipeManager recipeManager)
        {
            this.recipeManager = recipeManager;
        }

        public void OnGet()
        {
            Recipes = recipeManager.GetAllRecipes();
        }
    }
}
