using System.Runtime.CompilerServices;

namespace entity_classes
{
    public class TypeIngredient
    {
        private int idTypeIngredient;
        private string nameTypeIngredient;

        public TypeIngredient(int idTypeIngredient, string nameTypeIngredient)
        {
            IdTypeIngredient = idTypeIngredient;
            NameTypeIngredient = nameTypeIngredient;
        }

        public int IdTypeIngredient
        {
            get { return idTypeIngredient; }
            private set
            {
                idTypeIngredient = value;
            }
        }

        public string NameTypeIngredient
        {
            get { return nameTypeIngredient; }
            private set
            {
                nameTypeIngredient = value;
            }
        }
    }
}
