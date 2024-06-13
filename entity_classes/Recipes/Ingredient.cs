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

        public int GetId()
        {
            return idIngredient;
        }

        public string GetName()
        {
            return name;
        }

        public TypeIngredient GetType()
        {
            return type;
        }
    }
}