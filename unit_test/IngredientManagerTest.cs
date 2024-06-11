using db_helpers;
using entity_classes;
using exceptions;
using manager_classes;
using Moq;

namespace unit_tests
{
    [TestClass]
    public class IngredientManagerTest
    {
        private Mock<IDBIngredientHelper> mockDbHelper;
        private IngredientManager manager;

        [TestInitialize]
        public void SetUp()
        {
            mockDbHelper = new Mock<IDBIngredientHelper>();
            manager = new IngredientManager(mockDbHelper.Object);
        }

        [TestMethod]
        public void GetAllTypeIngredients_ReturnsAllTypeIngredients()
        {
            // Arrange
            var expectedTypes = new List<TypeIngredient>
            {
                new TypeIngredient(1, "Spice"),
                new TypeIngredient(2, "Vegetable")
            };
            mockDbHelper.Setup(m => m.GetAllTypes()).Returns(expectedTypes);

            // Act
            var result = manager.GetAllTypeIngredients();

            // Assert
            Assert.AreEqual(expectedTypes, result);
        }

        [TestMethod]
        public void AddIngredient_ValidatesAndAddsIngredient()
        {
            // Arrange
            var type = new TypeIngredient(2, "Vegetable");
            var newIngredient = new Ingredient(1, "Tomato", type);
            mockDbHelper.Setup(m => m.DoesIngredientExist(newIngredient.NameIngredient)).Returns(false);

            // Act
            manager.AddIngredient(newIngredient);

            // Assert
            mockDbHelper.Verify(m => m.AddIngredient(newIngredient), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistIngredientException))]
        public void AddIngredient_ThrowsExceptionIfIngredientExists()
        {
            // Arrange
            var type = new TypeIngredient(2, "Vegetable");
            var newIngredient = new Ingredient(1, "Tomato", type);
            mockDbHelper.Setup(m => m.DoesIngredientExist(newIngredient.NameIngredient)).Returns(true);

            // Act
            manager.AddIngredient(newIngredient);
        }
    }
}
