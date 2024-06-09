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
        public void AddReview(Review review, int userId)
        {
            reviewHelper.InsertReview(review, userId);
        }

        public List<Review> GetReviewsByRecipeId(int recipeId)
        {
            var reviews = reviewHelper.GetReviewsByRecipeId(recipeId);
            var recipe = recipeHelper.GetRecipeById(recipeId);
            foreach (var review in reviews)
            {
                review.SetRecipe(recipe);
            }
            return reviews;
        }
    }
}
