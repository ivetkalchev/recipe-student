using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes
{
    public class Review
    {
        private int idReview;
        private Recipe recipe;
        private decimal ratingValue;
        private string? reviewText;
        private DateTime publishDate;

        public Review(int idReview, Recipe recipe, decimal ratingValue, string? reviewText, DateTime publishDate)
        {
            this.idReview = idReview;
            this.recipe = recipe;
            this.ratingValue = ratingValue;
            this.reviewText = reviewText;
            this.publishDate = publishDate;
        }

        public int getIdReview()
        {
            return idReview;
        }

        public Recipe getRecipe()
        {
            return recipe;
        }

        public decimal getRatingValue()
        {
            return ratingValue;
        }

        public string? getReviewText()
        {
            return reviewText;
        }

        public DateTime getPublishDate()
        {
            return publishDate;
        }
    }
}
