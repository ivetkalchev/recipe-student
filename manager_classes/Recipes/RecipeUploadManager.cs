using entity_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes.Recipes
{
    //add logic
    public class RecipeUploadManager
    {
        public void UploadRecipe(Recipe Recipe)
        {
            Recipe.SetApproval(true);
        }
    }
}
