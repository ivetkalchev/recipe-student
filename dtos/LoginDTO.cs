using exceptions;
using System.Text.RegularExpressions;

namespace dtos
{
    public class LoginDTO
    {
        private string username;
        private string password;

        public LoginDTO(string username, string password)
        {
            Username = username;
            Password = password;
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

        public string Password
        {
            get { return password; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException(nameof(Password));

                if (value.Length < 8 || !Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~])[A-Za-z\d!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~]+$"))
                    throw new InvalidPasswordFormatException();

                password = value;
            }
        }
    }
}
