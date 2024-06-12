using db_helpers;
using entity_classes;
using exceptions;
using manager_classes;
using Moq;

namespace unit_tests
{
    [TestClass]
    public class UserManagerTest
    {
        private Mock<IDBUserHelper> mockDbHelper;
        private UserManager manager;

        [TestInitialize]
        public void SetUp()
        {
            mockDbHelper = new Mock<IDBUserHelper>();
            manager = new UserManager(mockDbHelper.Object);
        }

        [TestMethod]
        public void RegisterDesktopUser_ValidUser_ReturnsTrue()
        {
            // Arrange
            var role = new Role(1, "User");
            var gender = new Gender(1, "Male");
            var birthdate = new DateTime(1996, 12, 30);
            var newUser = new DesktopUser(1, "testUser", "test@example.com", "Password#2", role, "Test", "User", 12345656, gender, birthdate);

            mockDbHelper.Setup(m => m.IsUsernameTaken(newUser.GetUsername())).Returns(false);
            mockDbHelper.Setup(m => m.IsEmailTaken(newUser.GetEmail())).Returns(false);
            mockDbHelper.Setup(m => m.IsBSNTaken(newUser.GetBsn())).Returns(false);

            // Act
            var result = manager.RegisterDesktopUser(newUser);

            // Assert
            Assert.IsTrue(result, "The RegisterDesktopUser method did not return true for a valid user.");
            mockDbHelper.Verify(m => m.InsertDesktopUser(It.IsAny<DesktopUser>()), Times.Once);
        }



        [TestMethod]
        [ExpectedException(typeof(AlreadyExistUserException))]
        public void RegisterDesktopUser_DuplicateUsername_ThrowsException()
        {
            // Arrange
            var role = new Role(1, "User");
            var gender = new Gender(1, "Male");
            var newUser = new DesktopUser(1, "testUser", "test@example.com", "password", role, "Test", "User", 12345, gender, DateTime.Now);
            mockDbHelper.Setup(m => m.IsUsernameTaken(newUser.GetUsername())).Returns(true);

            // Act
            manager.RegisterDesktopUser(newUser);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistUserException))]
        public void RegisterDesktopUser_DuplicateEmail_ThrowsException()
        {
            // Arrange
            var role = new Role(1, "User");
            var gender = new Gender(1, "Male");
            var newUser = new DesktopUser(1, "testUser", "test@example.com", "password", role, "Test", "User", 12345, gender, DateTime.Now);
            mockDbHelper.Setup(m => m.IsUsernameTaken(newUser.GetUsername())).Returns(false);
            mockDbHelper.Setup(m => m.IsEmailTaken(newUser.GetEmail())).Returns(true);

            // Act
            manager.RegisterDesktopUser(newUser);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistUserException))]
        public void RegisterDesktopUser_DuplicateBsn_ThrowsException()
        {
            // Arrange
            var role = new Role(1, "User");
            var gender = new Gender(1, "Male");
            var newUser = new DesktopUser(1, "testUser", "test@example.com", "password", role, "Test", "User", 12345, gender, DateTime.Now);
            mockDbHelper.Setup(m => m.IsUsernameTaken(newUser.GetUsername())).Returns(false);
            mockDbHelper.Setup(m => m.IsEmailTaken(newUser.GetEmail())).Returns(false);
            mockDbHelper.Setup(m => m.IsBSNTaken(newUser.GetBsn())).Returns(true);

            // Act
            manager.RegisterDesktopUser(newUser);
        }
    }
}
