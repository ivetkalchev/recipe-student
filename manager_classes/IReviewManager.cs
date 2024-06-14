using entity_classes;

namespace manager_classes
{
    public interface IReviewManager
    {
        void AddReview(Review review);
        void DeleteReview(int reviewId);
        Review GetReviewById(int reviewId);
        List<Review> GetReviewsByRecipeId(int recipeId);
        void UpdateReview(int reviewId, decimal ratingValue, string reviewText);
    }
}