using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public class RecipeManager
    {
        public void SubmitRecipe(Recipe recipe)
        {
            //user submits recipe for approval of manager
        }
        public void UploadRecipe(Recipe recipe)
        {
            //manager uploads directly a recipe
        }
        public void ApproveRecipe(List<Recipe> submittedRecipes)
        {
            //manager approves a recipe, submitted by the web user
        }
        public void DenyRecipe(List<Recipe> submittedRecipes)
        {
            //manager denies a recipe, submitted by the web user
        }
        public void RemoveRecipe(Recipe recipe)
        {
            //manager or web user removes a recipe they posted
        }
        public void EditRecipe(Recipe recipe)
        {
            //manager or web user edits a recipe they posted
        }
    }
}
