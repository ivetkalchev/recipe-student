using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe
{
    public class Rating
    {
        public int RatingValue { get; private set; }

        public Rating(int ratingValue)
        {
            if (ratingValue < 0 && ratingValue >= 5)
            {
                throw new ArgumentException("Rating value must be between 0 and 5.");
            }
            RatingValue = ratingValue;
        }

        public void AddRating(int newRating)
        {
            if (newRating < 0 && newRating >= 5)
            {
                throw new ArgumentException("Rating value must be between 0 and 5.");
            }
            RatingValue = newRating;
        }

        public void EditRating(int updatedRating)
        {
            if (updatedRating < 0 && updatedRating >= 5)
            {
                throw new ArgumentException("Rating value must be between 0 and 5.");
            }
            RatingValue = updatedRating;
        }

        public void DeleteRating()
        {
            RatingValue = 0;
        }
    }
}
