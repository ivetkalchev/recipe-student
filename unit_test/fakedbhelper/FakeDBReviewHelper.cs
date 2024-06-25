using db_helpers;
using entity_classes;

namespace manager_classes
{
    public class FakeDBReviewHelper : IDBReviewHelper
    {
        private List<Review> reviews = new List<Review>();

        public void InsertReview(Review review)
        {
            reviews.Add(review);
        }

        public List<Review> GetReviewsByRecipeId(int recipeId)
        {
            return reviews.FindAll(r => r.GetRecipe().GetIdRecipe() == recipeId);
        }

        public Review GetReviewById(int reviewId)
        {
            return reviews.Find(r => r.GetIdReview() == reviewId);
        }

        public void DeleteReview(int reviewId)
        {
            reviews.RemoveAll(r => r.GetIdReview() == reviewId);
        }

        public void UpdateReview(int reviewId, decimal ratingValue, string reviewText)
        {
            var review = reviews.Find(r => r.GetIdReview() == reviewId);
            if (review != null)
            {
                review = new Review(reviewId, review.GetRecipe(), ratingValue, reviewText);
                reviews.RemoveAll(r => r.GetIdReview() == reviewId);
                reviews.Add(review);
            }
        }
    }
}