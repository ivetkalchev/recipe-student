using entity_classes.Users;

namespace exceptions_classes
{
    public class UnauthorizedEmployeeAccessException : Exception
    {
        public UnauthorizedEmployeeAccessException(DesktopUser user)
            : base($"Access Denied: User '{user.GetUsername()}' with role '{user.GetRole()}' does not have permission to manage employees.")
        {
        }

        public UnauthorizedEmployeeAccessException(DesktopUser user, string message)
            : base($"Access Denied: User '{user.GetUsername()}' with role '{user.GetRole()}'. {message}")
        {
        }

        public UnauthorizedEmployeeAccessException(DesktopUser user, string message, Exception innerException)
            : base($"Access Denied: User '{user.GetUsername()}' with role '{user.GetRole()}'. {message}", innerException)
        {
        }
    }
}
