using System.Data;
using System.Reflection;
using enum_classes.Users;

namespace DTOs
{
    public class DesktopUserDTO : UserDTO
    {
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Bsn { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string SecurityAnswer { get; set; }
    }
}
