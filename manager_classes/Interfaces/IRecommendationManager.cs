using entity_classes;

namespace manager_classes
{
    public interface IRecommendationManager
    {
        List<Recipe> GetRecipesLikedByUsers(List<int> userIds, int count);
        List<Recipe> GetTopMostLikedRecipes(int count);
        List<int> GetUsersWithSimilarLikes(int userId);
        bool HasLikedRecipes(int userId);
    }
}
