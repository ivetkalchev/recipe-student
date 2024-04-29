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
        private int submittedRecipes;
        private int approvedRecipes;
        private int deniedRecipes;
        public WebUser(int idUser, string username, string email, string password, int submittedRecipes, 
            int approvedRecipes, int deniedRecipes) : base(idUser, username, email, password)
        {
            this.submittedRecipes = submittedRecipes;
            this.approvedRecipes = approvedRecipes;
            this.deniedRecipes = deniedRecipes;
        }
    }
}
