using entity_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes.Recipes
{
    public class RecipeApprovalManager
    {
        public void ApproveRecipe(Recipe submittedRecipe)
        {
            submittedRecipe.SetApproval(true);
        }
        public void DenyRecipe(Recipe submittedRecipe)
        {
            submittedRecipe.SetApproval(false);
        }
    }
}
