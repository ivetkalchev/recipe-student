using entity_classes;

namespace manager_classes
{
    public interface IUserManager
    {
        bool IsBSNTaken(int bsn);
        bool IsEmailTaken(string email);
        bool IsUsernameTaken(string username);
        bool IsValidPassword(string password);
        DesktopUser LoginDesktopUser(string email, string password);
        bool RegisterDesktopUser(DesktopUser desktopUser);
    }
}