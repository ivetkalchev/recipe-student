namespace exceptions
{
    public class InvalidIngredientException : Exception
    {
        public InvalidIngredientException(string message) : base(message) { }
    }

    public class NullIngredientException : InvalidIngredientException
    {
        public NullIngredientException(string ingredientAttribute) : base($"The {ingredientAttribute} cannot be left empty.") { }
    }

    public class AlreadyExistIngredientException : InvalidIngredientException
    {
        public AlreadyExistIngredientException(string ingredientName) : base($"The ingredient {ingredientName} already exists.") { }
    }

    public class InvalidIngredientNameException : InvalidIngredientException
    {
        public InvalidIngredientNameException() : base("The ingredient name is invalid. The name must contain only letters and spaces.") { }
    }
}
