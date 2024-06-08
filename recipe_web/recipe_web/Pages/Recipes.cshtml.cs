using Microsoft.AspNetCore.Mvc.RazorPages;
using entity_classes;
using manager_classes;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

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
            int totalRecipes = recipeManager.GetTotalRecipesCount(SearchQuery);
            TotalPages = (int)Math.Ceiling(totalRecipes / (double)PageSize);
            Recipes = recipeManager.GetPagedRecipes(PageNumber, PageSize, SearchQuery);

            // Add debugging information
            Console.WriteLine($"Total recipes: {totalRecipes}, Displaying page {PageNumber} of {TotalPages}");
        }
    }
}
