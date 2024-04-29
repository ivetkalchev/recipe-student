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
        private Recipe recipe;
        private User user;

        private int idReview;
        private string reviewText;
        public Review(int idReview, Recipe recipe, User user, string reviewText)
        {
            this.idReview = idReview;
            this.recipe = recipe;
            this.user = user; 
            this.reviewText = reviewText;
        }
        public void SetReviewText(string updatedReviewText)
        {
            this.reviewText = updatedReviewText;
        }
    }
}
