using entity_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes.Filters
{
    public class CaffeineContentRecipeFilterStrategy : IRecipeFilterStrategy
    {
        private bool hasCaffeine;
        public CaffeineContentRecipeFilterStrategy(bool hasCaffeine)
        {
            this.hasCaffeine = hasCaffeine;
        }
        public List<Recipe> Filter(List<Recipe> recipes)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();
            foreach (var recipe in recipes)
            {
                if (recipe is Drink && ((Drink)recipe).GetCaffeineContent() == hasCaffeine)
                {
                    filteredRecipes.Add(recipe);
                }
            }
            return filteredRecipes;
        }
    }
}
