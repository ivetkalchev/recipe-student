using db_helpers;
using entity_classes;

namespace manager_classes
{
    public class ReviewManager : IReviewManager
    {
        private IDBReviewHelper reviewHelper;
        private IDBRecipeHelper recipeHelper;

        public ReviewManager(IDBReviewHelper reviewHelper, IDBRecipeHelper recipeHelper)
        {
            this.reviewHelper = reviewHelper;
            this.recipeHelper = recipeHelper;
        }

        public void AddReview(Review review)
        {
            reviewHelper.InsertReview(review);
        }

        public List<Review> GetReviewsByRecipeId(int recipeId)
        {
            return reviewHelper.GetReviewsByRecipeId(recipeId);
        }
    }
}
