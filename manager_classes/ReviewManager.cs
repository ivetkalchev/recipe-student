using db_helpers;
using entity_classes;
using System.Collections.Generic;

namespace manager_classes
{
    public class ReviewManager : IReviewManager
    {
        private readonly IDBReviewHelper reviewHelper;
        private readonly IDBRecipeHelper recipeHelper;

        //add proper edit method
        public ReviewManager(IDBReviewHelper reviewHelper, IDBRecipeHelper recipeHelper)
        {
            this.reviewHelper = reviewHelper ?? throw new ArgumentNullException(nameof(reviewHelper));
            this.recipeHelper = recipeHelper ?? throw new ArgumentNullException(nameof(recipeHelper));
        }

        public void AddReview(Review review)
        {
            reviewHelper.InsertReview(review);
        }

        public List<Review> GetReviewsByRecipeId(int recipeId)
        {
            return reviewHelper.GetReviewsByRecipeId(recipeId);
        }

        public Review GetReviewById(int reviewId)
        {
            return reviewHelper.GetReviewById(reviewId);
        }

        public void DeleteReview(int reviewId)
        {
            reviewHelper.DeleteReview(reviewId);
        }
    }
}
