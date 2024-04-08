using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using logic_layer.Raiting;

namespace logic_layer.Recipe.Recipe
{
    public class Drink : Recipe
    {
        private int servings;
        public Drink(int id, string title, List<Ingredient> ingredients, string instructions, int servings)
        : base(id, title, ingredients, instructions)
        {
            this.servings = servings;
        }
    }
}
