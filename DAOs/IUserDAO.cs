using DTOs;

namespace DAOs
{
    public interface IUserDAO
    {
        void CreateUser(DesktopUserDTO user);
        bool IsBsnTaken(int bsn);
        bool IsEmailTaken(string email);
        bool IsUsernameTaken(string username);
        bool UpdatePassword(string username, string newPassword);
        bool ValidateSecurityAnswer(string username, string securityAnswer);
        bool ValidateUserCredentials(string username, string password);
    }
}