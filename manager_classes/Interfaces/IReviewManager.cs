using entity_classes;

namespace manager_classes
{
    public interface IReviewManager
    {
        void AddReview(Review review, int userId);
        List<Review> GetReviewsByRecipeId(int recipeId);
    }
}