using entity_classes;

namespace manager_classes
{
    public interface IUserManager
    {
        void DeleteUser(DesktopUser user);
        void DeleteWebUser(WebUser user);
        List<DesktopUser> GetAllDesktopUsers();
        List<Gender> GetAllGenders();
        List<WebUser> GetAllWebUsers();
        Gender GetGenderByName(string genderName);
        WebUser GetWebUserByUsername(string username);
        bool IsBsnTaken(int bsn);
        bool IsBsnTakenByOtherUser(DesktopUser user, int bsn);
        bool IsEmailTaken(string email);
        bool IsEmailTakenByOtherUser(int user, string email);
        bool IsUsernameTaken(string username);
        DesktopUser LoginDesktopUser(string username, string password);
        WebUser LoginWebUser(string username, string password);
        void PromoteUserToAdmin(DesktopUser user);
        bool RegisterDesktopUser(DesktopUser newUser);
        bool RegisterWebUser(WebUser newUser);
        void UpdateDesktopUserDetails(DesktopUser user, string newFirstName, string newLastName, string newEmail, DateTime newBirthdate, Gender newGender, int newBsn);
        void UpdateWebUserDetails(WebUser user, string newCaption, string newEmail);
    }
}