using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes
{
    public class RecipeIngredient
    {
        private Ingredient ingredient;
        private decimal quantity;

        public RecipeIngredient(Ingredient ingredient, decimal quantity)
        {
            this.ingredient = ingredient;
            this.quantity = quantity;
        }

        public Ingredient GetIngredient()
        {
            return ingredient;
        }

        public decimal GetQuantity() 
        { 
            return quantity; 
        }
    }
}
