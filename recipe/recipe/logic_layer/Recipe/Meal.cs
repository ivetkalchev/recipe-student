using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using logic_layer.Raiting;
using logic_layer.Review;

namespace logic_layer.Recipe.Recipe
{
    public class Meal : Recipe
    {
        private int servings;
        public Meal(int id, string title, List<Ingredient> ingredients, string instructions, int servings)
            : base(id, title, ingredients, instructions)
        {
            this.servings = servings;
        }
        public void SetServings(int servings)
        {
            this.servings = servings;
        }
    }
}
