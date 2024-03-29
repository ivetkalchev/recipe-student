using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe
{
    public class Meal : Recipe
    {
        public int Servings { get; set; }
        public Rating MealRating { get; private set; }
        public Review MealReview { get; private set; }

        public Meal(string title, List<Ingredient> ingredients, string instructions, string mealType,
        int servings, Budget budgetFilter, TimeRequired timeRequiredFilter,
        Difficulty difficultyFilter, DietaryRestriction dietaryRestrictionFilter)
        : base(0, title, ingredients, instructions, difficultyFilter, timeRequiredFilter, dietaryRestrictionFilter, budgetFilter)
        {
            Servings = servings;
            MealRating = new Rating(0);
            MealReview = new Review("");
        }
    }
}
