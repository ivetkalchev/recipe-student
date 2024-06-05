using exceptions;

namespace entity_classes
{
    public class Ingredient
    {
        private int idIngredient;
        private string name;
        private TypeIngredient type;
        private decimal price;

        public Ingredient(int idIngredient, string name, TypeIngredient type, decimal price)
        {
            this.idIngredient = idIngredient;
            this.name = name;
            this.type = type;
            this.price = price;
        }

        public int GetIdIngredient()
        {
            return idIngredient;
        }

        public string GetName()
        {
            return name;
        }

        public TypeIngredient GetTypeIngredient()
        {
            return type;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public void IsIngredientNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                throw new InvalidIngredientNameException();
            }
        }

        public void IsIngredientPriceValid(decimal price)
        {
            if (price <= 0)
            {
                throw new InvalidPriceException();
            }
        }
    }
}