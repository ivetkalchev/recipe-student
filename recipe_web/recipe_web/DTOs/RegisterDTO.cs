using System.ComponentModel.DataAnnotations;

namespace recipe_web.DTOs
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
