using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Recipes;

namespace entity_classes.Users
{
    public class WebUser : User
    {
        private string caption;
        private List<Recipe> favouriteRecipes;
        public WebUser(int idUser, string username, string email, string password, string caption, List<Recipe> favouriteRecipes)
            : base(idUser, username, email, password)
        {
            this.caption = caption;
            this.favouriteRecipes = favouriteRecipes;
        }
        public string GetCaption()
        {  
            return caption; 
        }
        public List<Recipe> GetFavouritesRecipes()
        {
            return favouriteRecipes;
        }
        public void AddToFavourites(Recipe recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException(nameof(recipe));

            if (!favouriteRecipes.Contains(recipe))
                favouriteRecipes.Add(recipe);
        }
        public void RemoveFromFavourites(Recipe recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException(nameof(recipe));

            favouriteRecipes.Remove(recipe);
        }
    }
}

