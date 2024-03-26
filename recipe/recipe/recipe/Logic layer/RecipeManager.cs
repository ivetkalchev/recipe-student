using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace recipe
{
    public class RecipeManager
    {
        private List<Recipe>? favourites;

        private static int lastAssignedIdSubmittedRecipe = 0;

        private static int lastAssignedIdUploadedRecipe = 0;


        public void SubmitRecipe(Recipe recipe)
        {
            if (favourites.Contains(recipe))
            {
                Console.WriteLine("You have already submitted this recipe.");
                recipe.Id = ++lastAssignedIdSubmittedRecipe;

            }
            else
            {
                favourites.Add(recipe);
                Console.WriteLine("Recipe submitted successfully!");
            }
        }
        public void UploadRecipe(Recipe recipe)
        {
            Console.WriteLine("Recipe uploaded successfully!");
            recipe.Id = ++lastAssignedIdUploadedRecipe; 
        }

        public void ApproveRecipe(List<Recipe> submittedRecipes)
        {
            foreach (var recipe in submittedRecipes)
            {
                Console.WriteLine($"Recipe '{recipe.Title}'.");
            }
        }

        public void DenyRecipe(List<Recipe> submittedRecipes)
        {
            foreach (var recipe in submittedRecipes)
            {
                Console.WriteLine($"Recipe '{recipe.Title}'.");
            }
        }
    }
}
