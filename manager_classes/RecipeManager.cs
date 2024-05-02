using entity_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes
{
    public class RecipeManager
    {
        private List<Recipe> submittedRecipes;
        private List<Recipe> approvedRecipes;
        private List<Recipe> deniedRecipes;
        public RecipeManager()
        {
            submittedRecipes = new List<Recipe>();
            approvedRecipes = new List<Recipe>();
            deniedRecipes = new List<Recipe>();
        }
        public void SubmitRecipe(Recipe submittedRecipe)
        {
            submittedRecipes.Add(submittedRecipe);
        }
        public void ApproveRecipe(Recipe submittedRecipe)
        {
            submittedRecipes.Remove(submittedRecipe);
            submittedRecipe.Approve();
            approvedRecipes.Add(submittedRecipe);
        }
        public void DenyRecipe(Recipe submittedRecipe)
        {
            submittedRecipes.Remove(submittedRecipe);
            submittedRecipe.Deny();
            deniedRecipes.Add(submittedRecipe);
        }
        public void UploadRecipe(Recipe recipe)
        {
            approvedRecipes.Add(recipe);
        }
        public void DeleteRecipe(Recipe recipe)
        {
            if (submittedRecipes.Contains(recipe))
            {
                submittedRecipes.Remove(recipe);
            }
            if (approvedRecipes.Contains(recipe))
            {
                approvedRecipes.Remove(recipe);
            }
            if (deniedRecipes.Contains(recipe))
            {
                deniedRecipes.Remove(recipe);
            }
        }
        public List<Recipe> GetAllSubmittedRecipes()
        {
            return submittedRecipes.ToList();
        }
        public List<Recipe> GetAllApprovedRecipes()
        {
            return approvedRecipes.ToList();
        }
        public List<Recipe> GetAllDeniedRecipes()
        {
            return deniedRecipes.ToList();
        }
        public List<Recipe> GetAllRecipes()
        {
            List<Recipe> allRecipes = new List<Recipe>();
            allRecipes.AddRange(submittedRecipes);
            allRecipes.AddRange(approvedRecipes);
            allRecipes.AddRange(deniedRecipes);
            return allRecipes;
        }
    }
}
