using exceptions;

namespace entity_classes
{
    public class Review
    {
        private int idReview;
        private Recipe recipe;
        private decimal ratingValue;
        private string reviewText;
        private WebUser user;

        public Review(int idReview, Recipe recipe, decimal ratingValue, string reviewText)
        {
            IdReview = idReview;
            Recipe = recipe;
            RatingValue = ratingValue;
            ReviewText = reviewText;
        }

        public int IdReview
        {
            get { return idReview; }
            private set 
            {
                idReview = value;
            }
        }

        public Recipe Recipe
        {
            get { return recipe; }
            private set
            {
                recipe = value;
            }
        }

        public decimal RatingValue
        {
            get { return ratingValue; }
            private set
            {
                if (ratingValue < 0 || ratingValue > 5)
                    throw new InvalidReviewValueException();

                ratingValue = value;
            }
        }

        public string ReviewText
        {
            get { return reviewText; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new InvalidReviewTextException();

                reviewText = value;
            }
        }

        public WebUser User
        {
            get { return user; }
            private set
            {
                user = value;
            }
        }
    }
}
