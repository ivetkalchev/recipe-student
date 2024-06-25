using entity_classes;

namespace db_helpers
{
    public interface IDBRecommendationHelper
    {
        List<Recipe> GetRecipesLikedByUsers(List<int> userIds, int count);
        List<Recipe> GetUserLikedRecipes(int userId);
        List<int> GetUsersWithSimilarLikes(int userId);
    }
}