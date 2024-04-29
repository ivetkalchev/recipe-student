using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Recipes;
using enum_classes;

namespace manager_classes.Filters
{
    public interface IRecipeFilterStrategy
    {
        List<Recipe> Filter(List<Recipe> recipes);
    }
}
