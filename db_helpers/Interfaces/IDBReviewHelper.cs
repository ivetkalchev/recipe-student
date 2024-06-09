using entity_classes;

namespace db_helpers
{
    public interface IDBReviewHelper
    {
        List<Review> GetReviewsByRecipeId(int recipeId);
        void InsertReview(Review review, int userId);
    }
}