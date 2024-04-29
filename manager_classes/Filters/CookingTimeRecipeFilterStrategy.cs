using entity_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes.Filters
{
    public class CookingTimeRecipeFilterStrategy : IRecipeFilterStrategy
    {
        private int minCookingTime;
        private int maxCookingTime;
        public CookingTimeRecipeFilterStrategy(int minCookingTime, int maxCookingTime)
        {
            this.minCookingTime = minCookingTime;
            this.maxCookingTime = maxCookingTime;
        }
        public List<Recipe> Filter(List<Recipe> recipes)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();
            foreach (var recipe in recipes)
            {
                int cookingTime = recipe.GetCookingTime();
                if (cookingTime >= minCookingTime && cookingTime <= maxCookingTime)
                {
                    filteredRecipes.Add(recipe);
                }
            }
            return filteredRecipes;
        }
    }
}
