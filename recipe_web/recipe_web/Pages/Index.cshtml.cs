using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using manager_classes;
using entity_classes;
using System.Collections.Generic;
using System.Security.Claims;

namespace recipe_web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRecommendationManager recommendationManager;

        public List<Recipe> RecommendedRecipes { get; set; }

        public IndexModel(IRecommendationManager recommendationManager)
        {
            this.recommendationManager = recommendationManager;
        }

        public void OnGet()
        {
            var recommendationContext = new RecipeRecommendationContext();
            int userIdForRecommendation = 0;

            if (User.Identity.IsAuthenticated && Request.Cookies["CookiesAccepted"] == "true")
            {
                userIdForRecommendation = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (recommendationManager.HasLikedRecipes(userIdForRecommendation))
                {
                    recommendationContext.SetRecommendationStrategy(new SimilarUsersLikedRecipesStrategy(recommendationManager));
                }
                else
                {
                    recommendationContext.SetRecommendationStrategy(new MostLikedRecipesStrategy(recommendationManager));
                }
            }
            else
            {
                recommendationContext.SetRecommendationStrategy(new MostLikedRecipesStrategy(recommendationManager));
            }

            RecommendedRecipes = recommendationContext.GetRecommendedRecipes(userIdForRecommendation);
        }
    }
}
