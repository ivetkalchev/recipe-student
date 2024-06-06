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

        public User(int idUser, string username, string email, string password)
        {
            this.idUser = idUser;
            this.username = username;
            SetEmail(email);
            SetPassword(password);
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

        private void SetEmail(string email)
        {
            if (!IsEmailValid(email))
            {
                throw new InvalidEmailException();
            }
            this.email = email;
        }

        private void SetPassword(string password)
        {
            if (!IsPasswordValid(password))
            {
                throw new InvalidPasswordFormatException();
            }
            this.password = password;
        }

        private bool IsEmailValid(string email)
        {
            if (!email.Contains("@"))
            {
                return false;
            }
            return true;
        }

        private bool IsPasswordValid(string password)
        {
            if (password.Length < 8)
            {
                throw new InvalidPasswordLengthException();
            }
            //one lowercase and uppercase letter, number and special symbol
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
