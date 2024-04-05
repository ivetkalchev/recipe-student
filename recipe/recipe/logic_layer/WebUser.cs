using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public class WebUser : User
    {
        private List<Recipe> favourites;
        public WebUser(int id, string username, string password, string email) : base(id, username, password, email)
        {
            favourites = new List<Recipe>();
        }
        public void AddToFavourites(Recipe recipe)
        {
            favourites.Add(recipe);
        }
        public void DeleteFromFavourite(Recipe recipe)
        {
            favourites.Remove(recipe);
        }
    }
}
