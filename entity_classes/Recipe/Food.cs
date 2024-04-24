using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes.Recipe
{
    public class Food : Recipe
    {
        private int spicyLevel;
        public Food(int idRecipe, string title, int serving, int cookingTime, List<Ingredient> ingredients,
            string instructions, int spicyLevel) : base(idRecipe, title, serving, cookingTime, ingredients, instructions)
        {
            this.spicyLevel = spicyLevel;
        }
    }
}
