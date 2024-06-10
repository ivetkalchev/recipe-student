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
            this.idReview = idReview;
            this.recipe = recipe;
            this.ratingValue = ratingValue;
            this.reviewText = reviewText;
        }
        public Recipe GetRecipe()
        {
            return recipe;
        }

        public decimal GetRatingValue()
        {
            return ratingValue;
        }

        public string GetReviewText()
        {
            return reviewText;
        }

        public WebUser GetUser()
        {
            return user;
        }

        public void SetUser(WebUser user)
        {
            this.user = user;
        }
    }
}
