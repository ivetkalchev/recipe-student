using logic_layer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer.Review
{
    public class Review : IReviewable
    {
        private Dictionary<int, string> userReviews;

        public Review()
        {
            userReviews = new Dictionary<int, string>();
        }

        public void AddReview(int userId, string review)
        {
            if (userReviews.ContainsKey(userId))
            {
                userReviews[userId] = review;
            }
            else
            {
                userReviews.Add(userId, review);
            }
        }

        public void RemoveReview(int userId)
        {
            userReviews.Remove(userId);
        }

        public string GetReview(int userId)
        {
            if (userReviews.ContainsKey(userId))
            {
                return userReviews[userId];
            }
            else
            {
                return "";
            }
        }
    }
}
