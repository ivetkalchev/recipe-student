using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer.RecipeManager
{
    public interface IRecipeValidator
    {
        bool Validate(Recipe recipe);
    }
}
