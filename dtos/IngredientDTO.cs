using exceptions;
using entity_classes;
using System.Text.RegularExpressions;

namespace dtos
{
    public class IngredientDTO
    {
        private string name;
        private TypeIngredient type;

        public IngredientDTO(string name, TypeIngredient type)
        {
            Name = name;
            Type = type;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullIngredientException(nameof(Name));

                if (!Regex.IsMatch(value, @"^[a-zA-Z\s]+$"))
                    throw new InvalidIngredientNameException();

                name = value;
            }
        }

        public TypeIngredient Type
        {
            get { return type; }
            set
            {
                if (value == null)
                    throw new NullIngredientException(nameof(Type));

                type = value;
            }
        }
    }
}