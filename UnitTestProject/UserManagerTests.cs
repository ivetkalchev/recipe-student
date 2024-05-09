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
        public void ValidateUserCredentials_ValidCredentials_CallsValidateUserCredentials()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            string username = "testUser";
            string password = "password";

            userManager.ValidateUserCredentials(username, password);

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
        public void UpdatePassword_ValidUsernameAndNewPassword_CallsUpdatePassword()
        {
            var mockUserDAO = new Mock<IUserDAO>();
            var userManager = new UserManager(mockUserDAO.Object);
            string username = "testUser";
            string newPassword = "newPassword";

            userManager.UpdatePassword(username, newPassword);

            mockUserDAO.Verify(dao => dao.UpdatePassword(username, newPassword), Times.Once());
        }
    }
}
