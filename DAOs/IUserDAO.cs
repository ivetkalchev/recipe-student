using DTOs;

namespace DAOs
{
    public interface IUserDAO
    {
        void CreateDesktopUser(DesktopUserDTO user);
        void CreateWebUser(WebUserDTO user);
        ProfilePicDTO GetProfilePicByUsername(string username);
        WebUserDTO GetWebUserByUsername(string username);
        bool IsBsnTaken(int bsn);
        bool IsEmailTaken(string email);
        bool IsUsernameTaken(string username);
        bool UpdateDesktopPassword(string username, string newPassword);
        bool UpdateWebUserPassword(string username, string newPassword);
        bool UploadProfilePicture(int userId, string imagePath, string imageType);
        bool ValidateSecurityAnswer(string username, string securityAnswer);
        bool ValidateUserCredentials(string username, string password);
    }
}