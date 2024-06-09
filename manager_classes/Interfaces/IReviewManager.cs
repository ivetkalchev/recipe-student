using entity_classes;

namespace manager_classes
{
    public interface IReviewManager
    {
        void AddReview(Review review);
        List<Review> GetReviewsByRecipeId(int recipeId);
    }
}