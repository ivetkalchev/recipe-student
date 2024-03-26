using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe
{
    public class Customer : Users
    {
        private List<Recipe> favourites;

        public List<Recipe> Favourites
        {
            get { return favourites; }
            set { favourites = value; }
        }

        public Customer(Users user, string username, string password, string email, string firstName, string lastName)
            : base(0, username, password, email, firstName, lastName)
        {
            favourites = new List<Recipe>();
        }

        public void AddFavourites(Recipe recipe)
        {
            favourites.Add(recipe);
        }

        public void DeleteFavourite(Recipe recipe)
        {
            favourites.Remove(recipe);
        }
    }
}
