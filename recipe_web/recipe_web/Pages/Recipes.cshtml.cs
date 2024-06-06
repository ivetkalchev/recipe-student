using Microsoft.AspNetCore.Mvc.RazorPages;
using entity_classes;
using db_helpers;
using manager_classes;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace recipe_web.Pages
{
    public class RecipesModel : PageModel
    {
        private readonly IRecipeManager recipeManager;

        public List<Recipe> Recipes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }

        public RecipesModel(IRecipeManager recipeManager)
        {
            this.recipeManager = recipeManager;
        }

        public void OnGet()
        {
            var allRecipes = recipeManager.GetAllRecipes();
            Recipes = new List<Recipe>();

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                foreach (var recipe in allRecipes)
                {
                    if (recipe.GetTitle().IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        recipe.GetDescription().IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Recipes.Add(recipe);
                    }
                }
            }
            else
            {
                Recipes = allRecipes;
            }
        }
    }
}
