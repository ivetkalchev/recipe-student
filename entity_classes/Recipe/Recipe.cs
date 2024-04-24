using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes.Recipe
{
    public class Recipe
    {
        private int idRecipe;
        private string title;
        private int serving;
        private int cookingTime;
        private List<Ingredient> ingredients;
        private string instructions;
        protected Recipe(int idRecipe, string title, int serving, int cookingTime, List<Ingredient> ingredients, 
            string instructions)
        {
            this.idRecipe = idRecipe;
            this.title = title;
            this.serving = serving;
            this.cookingTime = cookingTime;
            this.ingredients = ingredients;
            this.instructions = instructions;
        }
    }
}
