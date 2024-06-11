namespace entity_classes
{
    public class IngredientRecipe
    {
        private Ingredient ingredient;
        private decimal quantity;
        private Unit unit;

        public IngredientRecipe(Ingredient ingredient, decimal quantity, Unit unit)
        {
            Ingredient = ingredient;
            Quantity = quantity;
            Unit = unit;
        }

        public Ingredient Ingredient
        {
            get { return ingredient; }
            private set { ingredient = value; }
        }

        public decimal Quantity
        {
            get { return quantity; }
            private set { quantity = value; }
        }

        public Unit Unit
        {
            get { return unit; }
            private set { unit = value; }
        }

        public string GetFormattedQuantity()
        {
            return quantity.ToString("G29");
        }

        public override string ToString()
        {
            return $"{ingredient.NameIngredient} - {quantity} {unit.NameUnit}";
        }
    }
}