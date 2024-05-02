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
        private List<Recipe> approvedRecipes;
        private List<Recipe> favouriteRecipes;
        public WebUser(int idUser, string username, string email, string password,
            List<Recipe> approvedRecipes, List<Recipe> favouriteRecipes)
            : base(idUser, username, email, password)
        {
            this.approvedRecipes = approvedRecipes;
            this.favouriteRecipes = favouriteRecipes;
        }
        public List<Recipe> GetApprovedRecipes()
        {
            return approvedRecipes;
        }
        public List<Recipe> GetFavouritesRecipes()
        {
            return favouriteRecipes;
        }
        public List<Recipe> AddToFavourites(Recipe recipe)
        {
            favouriteRecipes.Add(recipe);
            return favouriteRecipes;
        }
        public List<Recipe> RemoveFromToDoList(Recipe recipe)
        {
            favouriteRecipes.Remove(recipe);
            return favouriteRecipes;
        }
    }
}
