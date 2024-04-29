using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Ratings;
using entity_classes.Reviews;

namespace manager_classes
{
    public class ReviewManager
    {
        private List<Review> reviews = new List<Review>();
        public void AddReview(Review review)
        {
            reviews.Add(review);
        }
        public void DeleteReview(Review review)
        {
            reviews.Remove(review);
        }
        public void EditReview(Review review, string updatedReviewText)
        {
            review.SetReviewText(updatedReviewText);
        }
    }
}
