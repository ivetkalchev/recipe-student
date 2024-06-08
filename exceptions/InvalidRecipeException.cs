using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

