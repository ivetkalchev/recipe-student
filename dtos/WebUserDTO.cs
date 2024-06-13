using exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace dtos
{
    public class WebUserDTO
    {
        private string username;
        private string email;
        private string caption;

        public WebUserDTO(string username, string email, string caption)
        {
            Username = username;
            Email = email;
            Caption = caption;
        }

        public string Username
        {
            get { return username; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException("Username");

                username = value;
            }
        }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException("Email");

                if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new InvalidEmailException();

                email = value;
            }
        }

        [Required(ErrorMessage = "Caption is required.")]
        [StringLength(300, ErrorMessage = "Caption cannot be longer than 300 characters.")]
        public string Caption
        {
            get { return caption; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException("Caption");

                if (value.Length > 300)
                    throw new InvalidCaptionLengthException();

                caption = value;
            }
        }
    }
}