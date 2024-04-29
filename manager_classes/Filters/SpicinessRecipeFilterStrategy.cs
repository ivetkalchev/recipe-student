using entity_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes.Filters
{
    public class SpicinessRecipeFilterStrategy : IRecipeFilterStrategy
    {
        private bool isSpicy;
        public SpicinessRecipeFilterStrategy(bool isSpicy)
        {
            this.isSpicy = isSpicy;
        }
        public List<Recipe> Filter(List<Recipe> recipes)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();
            foreach (var recipe in recipes)
            {
                if (recipe is Food && ((Food)recipe).GetSpiciness() == isSpicy)
                {
                    filteredRecipes.Add(recipe);
                }
            }
            return filteredRecipes;
        }
    }
}
