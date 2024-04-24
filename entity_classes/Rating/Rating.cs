using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Recipe;
using entity_classes.User;

namespace entity_classes.Rating
{
    //should i initialize idRecipe and idUser
    public class Rating
    {
        private int idRating;
        private decimal rating;
        public Rating(int idRating, int idRecipe, int idUser, decimal rating)
        {
            this.idRating = idRating;
            this.rating = rating;
        }
    }
}
