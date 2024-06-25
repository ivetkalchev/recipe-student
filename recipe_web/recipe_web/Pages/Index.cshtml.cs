using manager_classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using entity_classes;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace recipe_web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRecipeRecommendationService recipeRecommendationService;

        public List<Recipe> RecommendedRecipes { get; set; }

        public IndexModel(IRecipeRecommendationService recipeRecommendationService)
        {
            this.recipeRecommendationService = recipeRecommendationService;
        }

        public void OnGet()
        {
            int userId = GetUserId();
            RecommendedRecipes = recipeRecommendationService.GetRecommendedRecipes(userId);
        }

        private int GetUserId()
        {
            if (User.Identity.IsAuthenticated)
            {
                return int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            }
            return 0;
        }
    }
}
