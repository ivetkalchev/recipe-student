using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public interface IReviewable
    {
        void AddReview(string newReview);
        void EditReview(string updatedReview);
        void DeleteReview();
        string GetReviewText();
    }
}
