using System.Data;
using System.Reflection;
using enum_classes.Users;

namespace DTOs
{
    public class DesktopUserDTO
    {
        public int IdUser { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Bsn { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string SecurityAnswer { get; private set; }
        public bool IsActive { get; private set; }
    }
}
