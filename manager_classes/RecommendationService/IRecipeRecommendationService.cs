using entity_classes;
using System.Collections.Generic;

namespace manager_classes
{
    public interface IRecipeRecommendationService
    {
        List<Recipe> GetRecommendedRecipes(int userId);
    }
}
