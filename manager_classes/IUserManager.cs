using entity_classes;

namespace manager_classes
{
    public interface IUserManager
    {
        bool IsBSNTaken(int bsn);
        bool IsEmailTaken(string email);
        bool IsUsernameTaken(string username);
        DesktopUser LoginDesktopUser(string email, string password);
        bool RegisterDesktopUser(DesktopUser desktopUser);
    }
}