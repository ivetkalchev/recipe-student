using entity_classes;

namespace manager_classes
{
    public interface IUserManager
    {
        void DeleteUser(DesktopUser user);
        List<DesktopUser> GetAllDesktopUsers();
        bool IsBSNTaken(int bsn);
        bool IsEmailTaken(string email);
        bool IsUsernameTaken(string username);
        bool IsValidPassword(string password);
        DesktopUser LoginDesktopUser(string username, string password);
        void PromoteUserToAdmin(DesktopUser user);
        bool RegisterDesktopUser(DesktopUser desktopUser);
        void UpdateUserDetails(DesktopUser user, string newLastName, string newUsername, string newEmail);
    }
}