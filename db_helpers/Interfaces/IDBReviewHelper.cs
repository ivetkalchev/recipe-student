using entity_classes;

namespace db_helpers
{
    public interface IDBReviewHelper
    {
        void InsertReview(Review review);
        List<Review> GetReviewsByRecipeId(int recipeId);
        Review GetReviewById(int reviewId);
        void DeleteReview(int reviewId);
    }

}