using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public class RecipeApprovalService
    {
        private readonly IRecipeValidator validator;
        public RecipeApprovalService(IRecipeValidator validator)
        {
            this.validator = validator;
        }
        public void ApproveRecipe(Recipe recipe)
        {
            if (validator.Validate(recipe))
            {
                //add logic to approve the recipe
            }
            else
            {
                //add logic if recipe fails validation
            }
        }
        public void DenyRecipe(Recipe recipe)
        {
            //add logic to deny the recipe
        }
    }

}
