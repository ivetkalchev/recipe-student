using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes.User
{
    public class WebUser : User
    {
        private int submittedRecipes;
        private int approvedRecipes;
        private int deniedRecipes;
        public WebUser(int idUser, string role, string username, string email, string password, 
            int submittedRecipes, int approvedRecipes, int deniedRecipes) : base(idUser, role, username, email, password)
        {
        }
    }
}
