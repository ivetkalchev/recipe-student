using entity_classes.Recipes;
using enum_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes.Filters
{
    public class DietaryRestrictionRecipeFilterStrategy : IRecipeFilterStrategy
    {
        private DietaryRestriction dietaryRestriction;
        public DietaryRestrictionRecipeFilterStrategy(DietaryRestriction dietaryRestriction)
        {
            this.dietaryRestriction = dietaryRestriction;
        }
        public List<Recipe> Filter(List<Recipe> recipes)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();
            foreach (var recipe in recipes)
            {
                if (recipe.GetDietaryRestriction() == dietaryRestriction)
                {
                    filteredRecipes.Add(recipe);
                }
            }
            return filteredRecipes;
        }
    }
}
