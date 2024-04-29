using entity_classes.Recipes;
using enum_classes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes.Filters
{
    public class DifficultyRecipeFilterStrategy : IRecipeFilterStrategy
    {
        private Difficulty difficulty;
        public DifficultyRecipeFilterStrategy(Difficulty difficulty)
        {
            this.difficulty = difficulty;
        }
        public List<Recipe> Filter(List<Recipe> recipes)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();
            foreach (var recipe in recipes)
            {
                if (recipe.GetDifficulty() == difficulty)
                {
                    filteredRecipes.Add(recipe);
                }
            }
            return filteredRecipes;
        }
    }
}
