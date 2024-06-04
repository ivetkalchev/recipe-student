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
        void InsertDesktopUser(DesktopUser newUser);
        bool IsBSNTaken(int bsn);
        bool IsBsnTakenByOtherUser(DesktopUser user, int bsn);
        bool IsEmailTaken(string email);
        bool IsEmailTakenByOtherUser(DesktopUser user, string email);
        bool IsUsernameTaken(string username);
        void PromoteUserToAdmin(DesktopUser user);
        void UpdateUserDetails(DesktopUser user, string newFirstName, string newLastName, string newEmail, DateTime newBirthdate, Gender newGender, int newBSN);
    }
}