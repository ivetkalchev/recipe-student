using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes.User
{
    public class User
    {
        private int idUser;
        private string role;
        private string username;
        private string email;
        private string password;
        protected User(int idUser, string role, string username, string email, string password)
        {
            this.idUser = idUser;
            this.role = role;
            this.username = username;
            this.email = email;
            this.password = password;
        }
    }
}
