using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public class Rating : IRatable
    {
        private decimal rating;
        public Rating(decimal rating)
        {
            SetRating(rating);
        }
        public void SetRating(decimal rating)
        {
            if (rating <= 0 || rating >= 5) 
            {
                throw new ArgumentException("Rating could be between 0 and 5.");
            }
            this.rating = rating;
        }
        public decimal GetRating()
        {
            return rating;
        }
        public void DeleteRating()
        {
            rating = 0;
        }
        public void EditRating(decimal newRating)
        {
            SetRating(newRating);
        }
    }
}
