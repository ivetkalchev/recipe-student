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

        protected void SetEmail(string email)
        {
            if (!IsEmailValid(email))
            {
                throw new InvalidEmailException();
            }
            this.email = email;
        }

        protected void SetPassword(string password)
        {
            if (!IsPasswordValid(password))
            {
                throw new InvalidPasswordFormatException();
            }
            this.password = password;
        }

        private bool IsEmailValid(string email)
        {
            return email.Contains("@");
        }

        private bool IsPasswordValid(string password)
        {
            if (password.Length < 8)
            {
                throw new InvalidPasswordLengthException();
            }

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~])[A-Za-z\d!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~]+$"))
            {
                return false;
            }

            return true;
        }

        public bool IsUserValid()
        {
            return IsEmailValid(email) && IsPasswordValid(password);
        }
    }
}
