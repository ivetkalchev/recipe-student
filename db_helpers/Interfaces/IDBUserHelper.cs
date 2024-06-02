using entity_classes;

namespace db_helpers
{
    public interface IDBUserHelper
    {
        void DeleteUser(DesktopUser user);
        List<DesktopUser> GetAllDesktopUsers();
        List<Gender> GetAllGenders();
        DesktopUser GetDesktopUser(string username, string hashedPassword);
        Gender GetGenderById(int genderId);
        void InsertDesktopUser(DesktopUser desktopUser);
        bool IsBSNTaken(int bsn);
        bool IsEmailTaken(string email);
        bool IsUsernameTaken(string username);
        void PromoteUserToAdmin(DesktopUser user);
        void UpdateUserDetails(DesktopUser user, string newLastName, string newEmail);
    }
}