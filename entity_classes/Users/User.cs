using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes.Users
{
    public abstract class User
    {
        private int idUser;
        private string username;
        private string email;
        private string password;
        public User(int idUser, string username, string email, string password)
        {
            this.idUser = idUser;
            this.username = username;
            this.email = email;
            this.password = password;
        }
        public string GetUsername()
        {
            return username;
        }
        public string GetEmail()
        {
            return email;
        }
        public string GetPassword()
        {
            return password;
        }
    }
}
