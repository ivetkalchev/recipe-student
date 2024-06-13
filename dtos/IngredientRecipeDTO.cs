using exceptions;
using entity_classes;

namespace dtos
{
    public class IngredientRecipeDTO
    {
        private IngredientDTO ingredient;
        private decimal quantity;
        private Unit unit;

        public IngredientRecipeDTO(IngredientDTO ingredient, decimal quantity, Unit unit)
        {
            Ingredient = ingredient;
            Quantity = quantity;
            Unit = unit;
        }

        public IngredientDTO Ingredient
        {
            get { return ingredient; }
            private set
            {
                if (value == null)
                    throw new NullRecipeException(nameof(Ingredient));

                ingredient = value;
            }
        }

        public decimal Quantity
        {
            get { return quantity; }
            private set
            {
                if (value <= 0)
                    throw new InvalidRecipeQuantityException(nameof(Quantity), (int)value);

                quantity = value;
            }
        }

        public Unit Unit
        {
            get { return unit; }
            private set
            {
                if (value == null)
                    throw new NullRecipeException(nameof(Unit));

                if (!IsValidUnitForType(value, Ingredient.Type))
                    throw new InvalidUnitForIngredientException(value.GetName(), Ingredient.Type.GetName());

                unit = value;
            }
        }

        private bool IsValidUnitForType(Unit unit, TypeIngredient type)
        {
            string typeName = type.GetName();
            string unitName = unit.GetName();

            switch (typeName)
            {
                case "Meats":
                case "Vegetables":
                case "Fruits":
                case "Sea Food":
                case "Dairy":
                    return unitName == "kg" || unitName == "g";

                case "Liquids":
                    return unitName == "l" || unitName == "ml";

                case "Nuts":
                case "Grains":
                    return unitName == "kg" || unitName == "g" || unitName == "cup(s)";

                case "Spices":
                    return unitName == "g" || unitName == "cup(s)" || unitName == "tsp" || unitName == "tbsp";

                default:
                    return false;
            }
        }
    }
}