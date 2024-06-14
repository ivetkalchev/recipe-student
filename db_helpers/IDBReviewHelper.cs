using entity_classes;

namespace db_helpers
{
    public interface IDBReviewHelper
    {
        void DeleteReview(int reviewId);
        Review GetReviewById(int reviewId);
        List<Review> GetReviewsByRecipeId(int recipeId);
        void InsertReview(Review review);
        void UpdateReview(int reviewId, decimal ratingValue, string reviewText);
    }
}