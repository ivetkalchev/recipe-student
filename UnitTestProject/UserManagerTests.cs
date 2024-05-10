using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using manager_classes;
using DAOs;
using DTOs;

namespace UnitTestProject
{
    [TestClass]
    public class UserManagerTests
    {
        [TestMethod]
        public void CreateDesktopUser_ValidUser_CallsCreateDesktopUser()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            var user = new DesktopUserDTO();

            userManager.CreateDesktopUser(user);

            mockUserDAO.Verify(dao => dao.CreateDesktopUser(user), Times.Once());
        }

        [TestMethod]
        public void IsUsernameTaken_ValidUsername_CallsIsUsernameTaken()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            string username = "testUser";

            userManager.IsUsernameTaken(username);

            mockUserDAO.Verify(dao => dao.IsUsernameTaken(username), Times.Once());
        }

        [TestMethod]
        public void IsEmailTaken_ValidEmail_CallsIsEmailTaken()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            string email = "test@example.com";

            userManager.IsEmailTaken(email);

            mockUserDAO.Verify(dao => dao.IsEmailTaken(email), Times.Once());
        }

        [TestMethod]
        public void IsBsnTaken_ValidBsn_CallsIsBsnTaken()
        { 
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            int bsn = 123456789;

            userManager.IsBsnTaken(bsn);

            mockUserDAO.Verify(dao => dao.IsBsnTaken(bsn), Times.Once());
        }

        [TestMethod]
        public void ValidateDesktopUserCredentials_ValidCredentials_CallsValidateDesktopUserCredentials()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            string username = "testUser";
            string password = "password";

            userManager.ValidateDesktopUserCredentials(username, password);

            mockUserDAO.Verify(dao => dao.ValidateUserCredentials(username, password), Times.Once());
        }

        [TestMethod]
        public void ValidateSecurityAnswer_ValidCredentials_CallsValidateSecurityAnswer()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            string username = "testUser";
            string securityAnswer = "answer";

            userManager.ValidateSecurityAnswer(username, securityAnswer);

            mockUserDAO.Verify(dao => dao.ValidateSecurityAnswer(username, securityAnswer), Times.Once());
        }

        [TestMethod]
        public void UpdateDesktopPassword_ValidUsernameAndNewPassword_CallsUpdateDesktopPassword()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            string username = "testUser";
            string newPassword = "newPassword";

            userManager.UpdateDesktopPassword(username, newPassword);

            mockUserDAO.Verify(dao => dao.UpdateDesktopPassword(username, newPassword), Times.Once());
        }

        [TestMethod]
        public void CreateWebUser_ValidUser_CallsCreateWebUser()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            var user = new WebUserDTO();

            userManager.CreateWebUser(user);

            mockUserDAO.Verify(dao => dao.CreateWebUser(user), Times.Once());
        }

        [TestMethod]
        public void ValidateWebUserCredentials_ValidCredentials_CallsValidateWebUserCredentials()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            string username = "webUser";
            string password = "password";
            string hashedPassword = PasswordHasher.HashPassword(password);

            userManager.ValidateWebUserCredentials(username, password);

            mockUserDAO.Verify(dao => dao.ValidateUserCredentials(username, hashedPassword), Times.Once());
        }

        [TestMethod]
        public void UpdateWebUserPassword_ValidUsernameAndNewPassword_CallsUpdateWebUserPassword()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            string username = "webUser";
            string newPassword = "newSecurePassword";

            userManager.UpdateWebUserPassword(username, newPassword);

            mockUserDAO.Verify(dao => dao.UpdateWebUserPassword(username, newPassword), Times.Once());
        }

        [TestMethod]
        public void UserExists_ValidUsername_CallsIsUsernameTaken()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            string username = "existingUser";

            userManager.UserExists(username);

            mockUserDAO.Verify(dao => dao.IsUsernameTaken(username), Times.Once());
        }

        [TestMethod]
        public void GetWebUserByUsername_ValidUsername_CallsGetWebUserByUsername()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            string username = "webUser";

            userManager.GetWebUserByUsername(username);

            mockUserDAO.Verify(dao => dao.GetWebUserByUsername(username), Times.Once());
        }
    }
}
