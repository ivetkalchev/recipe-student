using entity_classes;

namespace manager_classes
{
    public interface IRecommenderManager
    {
        List<Recipe> GetRecipesLikedByUsers(List<int> userIds, int count);
        List<Recipe> GetUserLikedRecipes(int userId);
        List<int> GetUsersWithSimilarLikes(int userId);
    }
}