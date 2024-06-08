using Microsoft.AspNetCore.Mvc.RazorPages;
using entity_classes;
using db_helpers;
using manager_classes;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace recipe_web.Pages
{
    public class RecipesModel : PageModel
    {
        private readonly IRecipeManager recipeManager;

        public List<Recipe> Recipes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        public int TotalPages { get; set; }
        private const int PageSize = 8;

        public RecipesModel(IRecipeManager recipeManager)
        {
            this.recipeManager = recipeManager;
        }

        public void OnGet()
        {
            var allRecipes = recipeManager.GetAllRecipes();

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                allRecipes = allRecipes.Where(r =>
                    r.GetTitle().IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r.GetDescription().IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();
            }

            TotalPages = (int)Math.Ceiling(allRecipes.Count / (double)PageSize);
            Recipes = allRecipes.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
