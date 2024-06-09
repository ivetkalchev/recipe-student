using db_helpers;
using entity_classes;
using System.Collections.Generic;

namespace manager_classes
{
    public class RecommenderManager : IRecommendationManager
    {
        private IDBRecommendationHelper recommendationHelper;

        public RecommenderManager(IDBRecommendationHelper recommendationHelper)
        {
            this.recommendationHelper = recommendationHelper;
        }

        public bool HasLikedRecipes(int userId)
        {
            return recommendationHelper.HasLikedRecipes(userId);
        }

        public List<int> GetUsersWithSimilarLikes(int userId)
        {
            return recommendationHelper.GetUsersWithSimilarLikes(userId);
        }

        public List<Recipe> GetTopMostLikedRecipes(int count)
        {
            return recommendationHelper.GetTopMostLikedRecipes(count);
        }

        public List<Recipe> GetRecipesLikedByUsers(List<int> userIds, int count)
        {
            return recommendationHelper.GetRecipesLikedByUsers(userIds, count);
        }
    }
}
