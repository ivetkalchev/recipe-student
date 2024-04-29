using entity_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes.Filters
{
    public class PriceRecipeFilterStrategy : IRecipeFilterStrategy
    {
        private decimal minPrice;
        private decimal maxPrice;
        public PriceRecipeFilterStrategy(decimal minPrice, decimal maxPrice)
        {
            this.minPrice = minPrice;
            this.maxPrice = maxPrice;
        }
        public List<Recipe> Filter(List<Recipe> recipes)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();
            foreach (var recipe in recipes)
            {
                decimal price = recipe.CalculatePrice();
                if (price >= minPrice && price <= maxPrice)
                {
                    filteredRecipes.Add(recipe);
                }
            }
            return filteredRecipes;
        }
    }
}
