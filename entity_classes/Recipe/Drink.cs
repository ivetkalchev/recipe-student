using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes.Recipe
{
    public class Drink : Recipe
    {
        private bool hasAlchohol;
        private bool hasCaffeine;
        public Drink(int idRecipe, string title, int serving, int cookingTime, List<Ingredient> ingredients, 
            string instructions, bool hasAlchohol, bool hasCaffeine) 
            : base(idRecipe, title, serving, cookingTime, ingredients, instructions)
        {
            this.hasAlchohol = hasAlchohol;
            this.hasCaffeine = hasCaffeine;
        }
    }
}
