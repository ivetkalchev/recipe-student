using entity_classes;

namespace db_helpers
{
    public interface IDBUserHelper
    {
        DesktopUser GetDesktopUser(string username, string hashedPassword);
        void InsertDesktopUser(DesktopUser desktopUser);
        bool IsBSNTaken(int bsn);
        bool IsEmailTaken(string email);
        bool IsUsernameTaken(string username);
        void UpdateUserDetails(DesktopUser user, string newLastName, string newUsername, string newEmail);
    }
}