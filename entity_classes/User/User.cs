using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes.Users
{
    public class User
    {
        private int idUser;
        private string username;
        private string email;
        private string password;
        protected User(int idUser, string username, string email, string password)
        {
            this.idUser = idUser;
            this.username = username;
            this.email = email;
            this.password = password;
        }
        public void SetUsername(string updatedUsername)
        {
            this.username = updatedUsername;
        }
        public void SetEmail(string updatedEmail)
        {
            this.email = updatedEmail;
        }
        public void SetPassword(string updatedPassword)
        {
            this.password = updatedPassword;
        }
    }
}
