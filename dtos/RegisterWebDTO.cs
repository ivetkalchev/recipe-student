using exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace dtos
{
    public class RegisterWebDTO
    {
        private string username;
        private string email;
        private string password;

        public RegisterWebDTO(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100, ErrorMessage = "Username cannot be longer than 100 characters.")]
        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException("Username");

                username = value;
            }
        }


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        public string Email
        {
            get { return email; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException("Email");

                if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new InvalidEmailException();

                email = value;
            }
        }


        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password
        {
            get { return password; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException("Password");

                if (value.Length < 8)
                    throw new InvalidPasswordLengthException();

                if (!Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$"))
                    throw new InvalidPasswordFormatException();

                password = value;
            }
        }
    }
}
