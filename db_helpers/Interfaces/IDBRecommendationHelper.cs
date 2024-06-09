using entity_classes;

namespace db_helpers
{
    public interface IDBRecommendationHelper
    {
        List<Recipe> GetRecipesLikedByUsers(List<int> userIds, int count);
        List<Recipe> GetTopMostLikedRecipes(int count);
        List<int> GetUsersWithSimilarLikes(int userId);
        bool HasLikedRecipes(int userId);
    }
}
