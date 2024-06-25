using db_helpers;
using entity_classes;

namespace manager_classes
{
    public class RecommenderManager : IRecommenderManager
    {
        private readonly IDBRecommendationHelper recommendationHelper;

        public RecommenderManager(IDBRecommendationHelper recommendationHelper)
        {
            this.recommendationHelper = recommendationHelper;
        }

        public List<int> GetUsersWithSimilarLikes(int userId)
        {
            return recommendationHelper.GetUsersWithSimilarLikes(userId);
        }

        public List<Recipe> GetRecipesLikedByUsers(List<int> userIds, int count)
        {
            return recommendationHelper.GetRecipesLikedByUsers(userIds, count);
        }

        public List<Recipe> GetUserLikedRecipes(int userId)
        {
            return recommendationHelper.GetUserLikedRecipes(userId);
        }
    }
}