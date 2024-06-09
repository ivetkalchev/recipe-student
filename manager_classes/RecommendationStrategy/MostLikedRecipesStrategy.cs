using entity_classes;

namespace manager_classes
{
    public class MostLikedRecipesStrategy : IRecipeRecommendationStrategy
    {
        private IRecommendationManager recommendationManager;

        public MostLikedRecipesStrategy(IRecommendationManager recommendationManager)
        {
            this.recommendationManager = recommendationManager;
        }

        public List<Recipe> GetRecommendedRecipes(int userId)
        {
            return recommendationManager.GetTopMostLikedRecipes(3);
        }
    }
}
