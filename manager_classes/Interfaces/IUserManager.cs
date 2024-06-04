using entity_classes;

namespace manager_classes
{
    public interface IUserManager
    {
        void DeleteUser(DesktopUser user);
        List<DesktopUser> GetAllDesktopUsers();
        List<Gender> GetAllGenders();
        Gender GetGenderByName(string genderName);
        bool IsBSNTaken(int bsn);
        bool IsEmailTaken(string email);
        bool IsPasswordValid(string password);
        bool IsUsernameTaken(string username);
        DesktopUser LoginDesktopUser(string username, string password);
        void PromoteUserToAdmin(DesktopUser user);
        bool RegisterDesktopUser(DesktopUser newUser);
        void UpdateUserDetails(DesktopUser user, string newFirstName, string newLastName, string newEmail, DateTime newBirthdate, Gender newGender, int newBSN);
    }
}