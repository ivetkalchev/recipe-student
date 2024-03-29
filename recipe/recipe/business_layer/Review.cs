using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe
{
    public class Review
    {
        public string ReviewText { get; private set; }
        public Review(string reviewText)
        {
            ReviewText = reviewText;
        }

        public void AddReview(string newReview)
        {
            if (string.IsNullOrWhiteSpace(newReview))
            {
                throw new ArgumentException("Review text cannot be empty.");
            }
            ReviewText = newReview;
        }

        public void EditReview(string updatedReview)
        {
            if (string.IsNullOrWhiteSpace(updatedReview))
            {
                throw new ArgumentException("Review text cannot be empty.");
            }
            ReviewText = updatedReview;
        }

        public void DeleteReview()
        {
            ReviewText = "";
        }
    }
}
