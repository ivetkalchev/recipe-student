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
            ValidateUser();
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

        private void ValidateUser()
        {
            IsUsernameValid(username);
            IsEmailValid(email);
            IsPasswordValid(password);
        }

        private void IsUsernameValid(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new NullUserException("username");
            }
        }

        private void IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new NullUserException("email");
            }

            if (!email.Contains("@"))
            {
                throw new InvalidEmailException();
            }
        }

        private void IsPasswordValid(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new NullUserException("password");
            }

            if (password.Length < 8)
            {
                throw new InvalidPasswordLengthException();
            }

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~])[A-Za-z\d!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~]+$"))
            {
                throw new InvalidPasswordFormatException();
            }
        }

        public bool IsUserValid()
        {
            return true;
        }
    }
}