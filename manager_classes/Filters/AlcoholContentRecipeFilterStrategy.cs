using entity_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes.Filters
{
    public class AlcoholContentRecipeFilterStrategy : IRecipeFilterStrategy
    {
        private bool isAlcoholic;
        public AlcoholContentRecipeFilterStrategy(bool isAlcoholic)
        {
            this.isAlcoholic = isAlcoholic;
        }
        public List<Recipe> Filter(List<Recipe> recipes)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();
            foreach (var recipe in recipes)
            {
                if (recipe is Drink && ((Drink)recipe).GetAlcoholicContent() == isAlcoholic)
                {
                    filteredRecipes.Add(recipe);
                }
            }
            return filteredRecipes;
        }
    }
}
