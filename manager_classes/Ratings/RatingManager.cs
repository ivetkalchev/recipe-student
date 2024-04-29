using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Ratings;
using entity_classes.Users;

namespace manager_classes.Ratings
{
    public class RatingManager
    {
        private List<Rating> ratings = new List<Rating>();
        public void AddRating(Rating rating)
        {
            ratings.Add(rating);
        }
        public void DeleteRating(Rating rating)
        {
            ratings.Remove(rating);
        }
        public void EditRating(Rating rating, decimal updatedRatingValue)
        {
            rating.SetRatingValue(updatedRatingValue);
        }
        public decimal CalculateAverageRating()
        {
            decimal totalRating = 0;

            foreach (Rating rating in ratings)
            {
                totalRating += rating.GetRatingValue();
            }

            decimal averageRating = totalRating / ratings.Count;
            return averageRating;
        }
    }
}
