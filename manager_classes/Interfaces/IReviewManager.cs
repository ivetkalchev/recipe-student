using entity_classes;
using System.Collections.Generic;

namespace manager_classes
{
    public interface IReviewManager
    {
        void AddReview(Review review);
        List<Review> GetReviewsByRecipeId(int recipeId);
        Review GetReviewById(int reviewId);
        void DeleteReview(int reviewId);
        void UpdateReview(int reviewId, decimal ratingValue, string reviewText);
        int GetReviewCountForRecipe(int recipeId); 
    }
}
