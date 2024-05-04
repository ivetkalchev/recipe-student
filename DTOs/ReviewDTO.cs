using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ReviewDTO
    {
        public int IdReview { get; private set; }
        public int IdRecipe { get; private set; }
        public int IdUser { get; private set; }
        public string ReviewText { get; private set; }
        public decimal RatingValue { get; private set; }
        public DateTime PublishDate { get; private set; }
    }
}
