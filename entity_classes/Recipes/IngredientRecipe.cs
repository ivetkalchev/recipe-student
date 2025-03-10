﻿namespace entity_classes
{
    public class IngredientRecipe
    {
        private Ingredient ingredient;
        private decimal quantity;
        private Unit unit;

        public IngredientRecipe(Ingredient ingredient, decimal quantity, Unit unit)
        {
            this.ingredient = ingredient;
            this.quantity = quantity;
            this.unit = unit;
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

        public string GetFormattedQuantity()
        {
            return quantity.ToString("G29");
        }

        public override string ToString()
        {
            return $"{ingredient.GetName()} - {GetFormattedQuantity()} {unit.GetName()}";
        }
    }
}
