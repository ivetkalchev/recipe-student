using entity_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes
{
    public class SortByRating : IRecipeSortingStrategy
    {
        private readonly IReviewManager reviewManager;

        public SortByRating(IReviewManager reviewManager)
        {
            this.reviewManager = reviewManager;
        }

        public List<Recipe> Sort(List<Recipe> recipes)
        {
            recipes.Sort(new Comparison<Recipe>(CompareByRating));
            return recipes;
        }

        private int CompareByRating(Recipe x, Recipe y)
        {
            decimal xRating = GetAverageRating(x.GetIdRecipe());
            decimal yRating = GetAverageRating(y.GetIdRecipe());
            return yRating.CompareTo(xRating);
        }

        private decimal GetAverageRating(int recipeId)
        {
            var reviews = reviewManager.GetReviewsByRecipeId(recipeId);
            if (reviews.Count == 0) return 0;
            decimal totalRating = 0;
            foreach (var review in reviews)
            {
                totalRating += review.GetRatingValue();
            }
            return totalRating / reviews.Count;
        }
    }
}
