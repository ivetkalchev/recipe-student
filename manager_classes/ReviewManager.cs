using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Reviews;

namespace manager_classes
{
    public class ReviewManager
    {
        private List<Review> reviews;

        public ReviewManager()
        {
            reviews = new List<Review>();
        }

        public void AddReview(Review review)
        {
            reviews.Add(review);
        }

        public void DeleteReview(Review review)
        {
            reviews.Remove(review);
        }

        public decimal CalculateAverageRating()
        {
            decimal totalRating = 0;
            foreach (Review review in reviews)
            {
                totalRating += review.GetRatingValue();
            }
            return reviews.Count > 0 ? totalRating / reviews.Count : 0;
        }

        public List<Review> GetAllReviews()
        {
            return reviews;
        }
    }
}
