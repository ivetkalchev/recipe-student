using System.Data;
using System.Reflection;
using enum_classes.Users;

namespace DTOs
{
    public class WebUserDTO
    {
		public int IdUser { get; private set; }
		public string Username { get; private set; }
		public string Email { get; private set; }
		public string Password { get; private set; }
	}
}
