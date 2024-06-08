using System;

namespace exceptions
{
    public class InvalidRecipeException : Exception
    {
        public InvalidRecipeException(string message) : base(message) { }
    }

    public class RecipeNotFoundException : InvalidRecipeException
    {
        public RecipeNotFoundException() : base("The recipe is not found!") { }
    }

    public class DuplicateRecipeException : InvalidRecipeException
    {
        public DuplicateRecipeException() : base("The recipe already exists!") { }
    }

    public class InvalidChoosenIngredientException : InvalidRecipeException
    {
        public InvalidChoosenIngredientException() : base("The ingredient is invalid!") { }
    }

    public class InvalidDietRestrictionException : InvalidRecipeException
    {
        public InvalidDietRestrictionException() : base("The diet restriction is invalid!") { }
    }

    public class InvalidDifficultyException : InvalidRecipeException
    {
        public InvalidDifficultyException() : base("The difficulty level is invalid!") { }
    }

    public class InvalidPreparationTimeException : InvalidRecipeException
    {
        public InvalidPreparationTimeException() : base("The preparation time is invalid!") { }
    }

    public class InvalidCookingTimeException : InvalidRecipeException
    {
        public InvalidCookingTimeException() : base("The cooking time is invalid!") { }
    }
}
