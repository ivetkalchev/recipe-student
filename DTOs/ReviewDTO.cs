using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ReviewDTO
    {
        public int IdReview { get; set; }
        public int IdRecipe { get; set; }
        public int IdUser { get; set; }
        public string ReviewText { get; set; }
        public decimal RatingValue { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
