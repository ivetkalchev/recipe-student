using entity_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes
{
    public interface IRecipeRecommendationStrategy
    {
        List<Recipe> GetRecommendedRecipes(int userId);
    }

}
