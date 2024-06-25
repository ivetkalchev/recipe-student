using entity_classes;

namespace manager_classes
{
    public interface IRecipeRecommendationService
    {
        List<Recipe> GetRecommendedRecipes(int userId);
    }
}