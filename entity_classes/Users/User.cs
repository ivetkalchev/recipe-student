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
            IdUser = idUser;
            Username = username;
            Email = email;
            Password = password;
        }

        public int IdUser
        {
            get { return idUser; }
            private set { idUser = value; }
        }

        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException(nameof(Username));

                username = value;
            }
        }

        public string Email
        {
            get { return email; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException(nameof(Email));

                if (!value.Contains("@"))
                    throw new InvalidEmailException();

                email = value;
            }
        }

        public string Password
        {
            get { return password; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException(nameof(Password));

                if (value.Length < 8)
                    throw new InvalidPasswordLengthException();

                if (!Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~])[A-Za-z\d!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~]+$"))
                    throw new InvalidPasswordFormatException();

                password = value;
            }
        }
    }
}