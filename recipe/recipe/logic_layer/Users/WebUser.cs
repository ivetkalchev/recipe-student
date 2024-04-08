using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer.Users
{
    public class WebUser : User
    {
        private List<Recipe> favourites;
        public WebUser(int id, string username, string hashedPassword, string salt, string email)
            : base(id, "webUser", username, hashedPassword, salt, email)
        {
            favourites = new List<Recipe>();
        }
        public void AddToFavourites(Recipe recipe)
        {
            if (!favourites.Contains(recipe))
            {
                favourites.Add(recipe);
            }
        }
        public void RemoveFromFavourites(Recipe recipe)
        {
            favourites.Remove(recipe);
        }
        public IEnumerable<Recipe> GetFavourites()
        {
            return favourites.AsReadOnly();
        }
    }
}
