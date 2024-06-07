using exceptions;

namespace entity_classes
{
    public class Ingredient
    {
        private int idIngredient;
        private string name;
        private TypeIngredient type;

        public Ingredient(int idIngredient, string name, TypeIngredient type)
        {
            this.idIngredient = idIngredient;
            this.name = name;
            this.type = type;
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

        public void IsIngredientNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                throw new InvalidIngredientNameException();
            }
        }
    }
}