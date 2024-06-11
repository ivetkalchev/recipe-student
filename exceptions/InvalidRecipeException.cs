using System;

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

    public class InvalidReviewValueReview : InvalidRecipeException
    {
        public InvalidReviewValueReview() : base("The rating is invalid!") { }
    }

    public class InvalidReviewTextReview : InvalidRecipeException
    {
        public InvalidReviewTextReview() : base("The review text cannot be empty!") { }
    }
}
