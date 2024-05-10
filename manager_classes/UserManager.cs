using DAOs;
using DTOs;
using entity_classes.Users;

namespace manager_classes
{
    public class UserManager : IUserManager
    {
        private IUserDAO userDAO;

        public UserManager(IUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }

        public bool IsUsernameTaken(string username)
        {
            return userDAO.IsUsernameTaken(username);
        }

        public bool IsEmailTaken(string email)
        {
            return userDAO.IsEmailTaken(email);
        }

        public bool IsBsnTaken(int bsn)
        {
            return userDAO.IsBsnTaken(bsn);
        }

        public void CreateDesktopUser(DesktopUserDTO user)
        {
            if (userDAO != null)
            {
                userDAO.CreateDesktopUser(user);
            }
            else
            {
                throw new InvalidOperationException("UserDAO is not initialized.");
            }
        }

        public void CreateWebUser(WebUserDTO user)
        {
            if (userDAO != null)
            {
                userDAO.CreateWebUser(user);
            }
            else
            {
                throw new InvalidOperationException("UserDAO is not initialized.");
            }
        }

        public bool ValidateDesktopUserCredentials(string username, string password)
        {
            return userDAO.ValidateUserCredentials(username, password);
        }

        public bool ValidateWebUserCredentials(string username, string password)
        {
            string hashedPassword = PasswordHasher.HashPassword(password);
            return userDAO.ValidateUserCredentials(username, hashedPassword);
        }

        public bool ValidateSecurityAnswer(string username, string securityAnswer)
        {
            return userDAO.ValidateSecurityAnswer(username, securityAnswer);
        }

        public bool UpdateDesktopPassword(string username, string newPassword)
        {
            return userDAO.UpdateDesktopPassword(username, newPassword);
        }
        public bool UpdateWebUserPassword(string username, string newPassword)
        {
            return userDAO.UpdateWebUserPassword(username, newPassword);
        }
        public bool UserExists(string username)
        {
            return userDAO.IsUsernameTaken(username);
        }

        public WebUserDTO GetWebUserByUsername(string username)
        {
            return userDAO.GetWebUserByUsername(username);
        }
	}
}
