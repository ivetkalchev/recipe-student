using DTOs;

public interface IUserManager
{
    void CreateDesktopUser(DesktopUserDTO user);
    void CreateWebUser(WebUserDTO user);
    WebUserDTO GetWebUserByUsername(string username);
    bool IsBsnTaken(int bsn);
    bool IsEmailTaken(string email);
    bool IsUsernameTaken(string username);
    bool UpdateDesktopPassword(string username, string newPassword);
    bool UpdateWebUserPassword(string username, string newPassword);
    bool UserExists(string username);
    bool ValidateDesktopUserCredentials(string username, string password);
    bool ValidateSecurityAnswer(string username, string securityAnswer);
    bool ValidateWebUserCredentials(string username, string password);
}