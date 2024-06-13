using exceptions;
using System.Text.RegularExpressions;

namespace entity_classes
{
    public abstract class User
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

        public int GetIdUser()
        {
            return idUser;
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
