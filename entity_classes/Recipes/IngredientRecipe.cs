using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes
{
    public class IngredientRecipe
    {
        private Recipe recipe;
        private Ingredient ingredient;
        private decimal quantity;
        private Unit unit;

        public IngredientRecipe(Recipe recipe, Ingredient ingredient, decimal quantity, Unit unit)
        {
            this.recipe = recipe;
            this.ingredient = ingredient;
            this.quantity = quantity;
            this.unit = unit;
        }

        public Recipe GetRecipe()
        {
            return recipe;
        }

        public Ingredient GetIngredient()
        {
            return ingredient;
        }

        public decimal GetQuantity() 
        { 
            return quantity; 
        }

        public Unit GetUnit()
        {
            return unit;
        }
    }
}
