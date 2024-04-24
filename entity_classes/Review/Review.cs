using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes.Review
{
    public class Review
    {
        private int idReview;
        private string review;
        public Review(int idReview, int idRecipe, int idUser, string review)
        {
            this.idReview = idReview;
            this.review = review;
        }
    }
}
