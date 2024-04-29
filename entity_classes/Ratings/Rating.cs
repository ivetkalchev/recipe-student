using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Recipes;
using entity_classes.Users;

namespace entity_classes.Ratings
{
    public class Rating
    {
        private Recipe recipe;
        private User user;

        private int idRating;
        private decimal ratingValue;
        public Rating(int idRating, Recipe recipe, User user, decimal ratingValue)
        {
            this.idRating = idRating;
            this.recipe = recipe;
            this.user = user;
            this.ratingValue = ratingValue;
        }
        public void SetRatingValue(decimal updatedRatingValue)
        {
            ratingValue = updatedRatingValue;
        }
        public decimal GetRatingValue()
        {
            return ratingValue;
        }
    }
}
