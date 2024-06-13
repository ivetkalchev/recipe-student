using exceptions;
using System.ComponentModel.DataAnnotations;

namespace dtos
{
    public class ReviewDTO
    {
        private decimal ratingValue;
        private string reviewText;

        public ReviewDTO(decimal ratingValue, string reviewText)
        {
            RatingValue = ratingValue;
            ReviewText = reviewText;
        }

        [Required]
        [Range(0, 5)]
        public decimal RatingValue
        {
            get { return ratingValue; }
            set
            {
                if (value < 0 || value > 5)
                    throw new InvalidReviewValueException();

                ratingValue = value;
            }
        }

        [Required]
        [StringLength(200)]
        public string ReviewText
        {
            get { return reviewText; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new InvalidReviewTextException();

                reviewText = value;
            }
        }
    }
}