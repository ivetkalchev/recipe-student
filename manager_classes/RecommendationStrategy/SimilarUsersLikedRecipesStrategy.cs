using entity_classes;
using System.Collections.Generic;

namespace manager_classes
{
    public class SimilarUsersLikedRecipesStrategy : IRecipeRecommendationStrategy
    {
        private IRecommendationManager recommendationManager;

        public SimilarUsersLikedRecipesStrategy(IRecommendationManager recommendationManager)
        {
            this.recommendationManager = recommendationManager;
        }

        public List<Recipe> GetRecommendedRecipes(int userId)
        {
            List<int> similarUsers = recommendationManager.GetUsersWithSimilarLikes(userId);
            return recommendationManager.GetRecipesLikedByUsers(similarUsers, 3);
        }
    }
}
