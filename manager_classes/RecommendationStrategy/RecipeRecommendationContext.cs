using entity_classes;

namespace manager_classes
{
    public class RecipeRecommendationContext
    {
        private IRecipeRecommendationStrategy recommendationStrategy;

        public void SetRecommendationStrategy(IRecipeRecommendationStrategy strategy)
        {
            this.recommendationStrategy = strategy;
        }

        public List<Recipe> GetRecommendedRecipes(int userId)
        {
            return recommendationStrategy.GetRecommendedRecipes(userId);
        }
    }
}
