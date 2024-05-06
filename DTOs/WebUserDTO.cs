using System.Data;
using System.Reflection;
using enum_classes.Users;

namespace DTOs
{
    public class WebUserDTO : UserDTO
    {
        public string Caption { get; set; }
    }
}
