using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public class Meal : Recipe
    {
        private int servings;
        private Rating mealRating;
        private Review mealReview;
        public Meal(int id, string title, List<Ingredient> ingredients, string instructions, int servings)
        : base(id, title, ingredients, instructions)
        {
            this.servings = servings;
            this.mealRating = new Rating(0);
            this.mealReview = new Review("");
        }
    }
}
