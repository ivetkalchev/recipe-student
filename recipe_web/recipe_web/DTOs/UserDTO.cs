using System.ComponentModel.DataAnnotations;

namespace recipe_web.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Caption is required.")]
        [StringLength(300, ErrorMessage = "Caption cannot be longer than 300 characters.")]
        public string Caption { get; set; }
    }
}