using logic_layer.Raiting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer.Rating
{
    public class Rating : IRatable
    {
        private Dictionary<int, decimal> userRatings;

        public Rating()
        {
            userRatings = new Dictionary<int, decimal>();
        }

        public void AddRating(int userId, decimal rating)
        {
            if (userRatings.ContainsKey(userId))
            {
                userRatings[userId] = rating;
            }
            else
            {
                userRatings.Add(userId, rating);
            }
        }

        public void RemoveRating(int userId)
        {
            userRatings.Remove(userId);
        }

        public decimal GetAverageRating()
        {
            if (userRatings.Count == 0)
                return 0;

            decimal sum = 0;
            foreach (var rating in userRatings.Values)
            {
                sum += rating;
            }

            decimal averageRating = sum / userRatings.Count;
            return averageRating;
        }
    }
}
