using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer.Review
{
    public interface IReviewable
    {
        void AddReview(int userId, string review);
        void RemoveReview(int userId);
        string GetReview(int userId);
    }
}
