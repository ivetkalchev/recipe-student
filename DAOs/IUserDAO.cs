using DTOs;

namespace DAOs
{
    public interface IUserDAO
    {
        bool AuthenticateUser(string username, string password, out DesktopUserDTO user);
        void CreateUser(DesktopUserDTO user);
        DesktopUserDTO GetUserByUsername(string username);
        bool IsBsnTaken(int bsn);
        bool IsEmailTaken(string email);
        bool IsUsernameTaken(string username);
    }
}