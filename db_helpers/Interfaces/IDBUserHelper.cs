using entity_classes;

namespace db_helpers
{
    public interface IDBUserHelper
    {
        void DeleteUser(DesktopUser user);
        void DeleteWebUser(WebUser user);
        List<DesktopUser> GetAllDesktopUsers();
        List<Gender> GetAllGenders();
        List<WebUser> GetAllWebUsers();
        DesktopUser GetDesktopUser(string username, string hashedPassword);
        Gender GetGenderById(int genderId);
        WebUser GetWebUser(string username, string hashedPassword);
        void InsertDesktopUser(DesktopUser newUser);
        void InsertWebUser(WebUser newUser);
        bool IsBSNTaken(int bsn);
        bool IsBsnTakenByOtherUser(DesktopUser user, int bsn);
        bool IsEmailTaken(string email);
        bool IsEmailTakenByOtherUser(DesktopUser user, string email);
        bool IsUsernameTaken(string username);
        bool IsWebEmailTaken(string email);
        bool IsWebUsernameTaken(string username);
        void PromoteUserToAdmin(DesktopUser user);
        void UpdateUserDetails(DesktopUser user, string newFirstName, string newLastName, string newEmail, DateTime newBirthdate, Gender newGender, int newBSN);
        void UpdateWebUserDetails(WebUser user, string newCaption, string newEmail);
    }
}