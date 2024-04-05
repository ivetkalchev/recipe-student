using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public class Review : IReviewable
    {
        private string review;
        public Review(string review)
        {
            if (string.IsNullOrWhiteSpace(review))
            {
                throw new ArgumentException("Review text cannot be empty.");
            }
            this.review = review;
        }
        public void AddReview(string newReview)
        {
            if (string.IsNullOrWhiteSpace(newReview))
            {
                throw new ArgumentException("Review text cannot be empty.");
            }
            review = newReview;
        }
        public void EditReview(string updatedReview)
        {
            if (string.IsNullOrWhiteSpace(updatedReview))
            {
                throw new ArgumentException("Review text cannot be empty.");
            }
            review = updatedReview;
        }
        public void DeleteReview()
        {
            review = "";
        }

        public string GetReviewText()
        {
            return review;
        }
    }
}
