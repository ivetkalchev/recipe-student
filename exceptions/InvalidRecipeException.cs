namespace exceptions
{
    public class InvalidRecipeException : Exception
    {
        public InvalidRecipeException(string message) : base(message) { }
    }

    public class NullRecipeException : InvalidRecipeException
    {
        public NullRecipeException(string recipeAttribute) : base($"The {recipeAttribute} cannot be left empty.") { }
    }

    public class LengthRecipeException : InvalidRecipeException
    {
        public LengthRecipeException(string recipeAttribute, int lengthCharacters) : base($"The {recipeAttribute} cannot be longer than {lengthCharacters} characters.") { }
    }

    public class InvalidTimeException : InvalidRecipeException
    {
        public InvalidTimeException(string typeTime) : base($"The {typeTime} is invalid!") { }
    }

    public class InvalidRecipeQuantityException : InvalidRecipeException
    {
        public InvalidRecipeQuantityException(string recipeQuantity, int quantity) : base($"The {recipeQuantity} is invalid! It cannot be {quantity}.") { }
    }
}
