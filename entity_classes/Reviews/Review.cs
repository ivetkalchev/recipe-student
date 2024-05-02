using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Users;
using entity_classes.Recipes;

namespace entity_classes.Reviews
{
    public class Review
    {
        private int idReview;
        private Recipe recipe;
        private User user;
        private string reviewText;
        private decimal ratingValue;
        public Review(int idReview, Recipe recipe, User user, string reviewText, decimal ratingValue)
        {
            this.idReview = idReview;
            this.recipe = recipe;
            this.user = user;
            this.reviewText = reviewText;
            this.ratingValue = ratingValue;
        }
        public string GetReviewText()
        {
            return reviewText;
        }
        public decimal GetRatingValue()
        {
            return ratingValue;
        }
    }
}
