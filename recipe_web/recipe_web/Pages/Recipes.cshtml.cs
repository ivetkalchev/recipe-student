using Microsoft.AspNetCore.Mvc.RazorPages;
using entity_classes;
using manager_classes;
using Microsoft.AspNetCore.Mvc;

namespace recipe_web.Pages
{
    public class RecipesModel : PageModel
    {
        private readonly IRecipeManager recipeManager;
        private readonly IReviewManager reviewManager;

        public List<Recipe> Recipes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public string SortOption { get; set; }
        public int TotalPages { get; set; }
        private const int PageSize = 10;

        public RecipesModel(IRecipeManager recipeManager, IReviewManager reviewManager)
        {
            this.recipeManager = recipeManager;
            this.reviewManager = reviewManager;
        }

        public void OnGet()
        {
            int totalRecipes = recipeManager.GetTotalRecipesCount(SearchQuery);
            TotalPages = (int)Math.Ceiling(totalRecipes / (double)PageSize);
            Recipes = recipeManager.GetPagedRecipes(PageNumber, PageSize, SearchQuery);

            var sorter = new RecipeSorter();
            switch (SortOption)
            {
                case "Title":
                    sorter.SetSortingStrategy(new SortByTitle());
                    break;
                case "PreparationTime":
                    sorter.SetSortingStrategy(new SortByPreparationTime());
                    break;
                case "Rating":
                    sorter.SetSortingStrategy(new SortByRating(reviewManager));
                    break;
                default:
                    sorter.SetSortingStrategy(new SortByTitle());
                    break;
            }
            Recipes = sorter.SortRecipes(Recipes);
        }
    }
}
