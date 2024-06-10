using entity_classes;
using manager_classes;
using Moq;

namespace unit_tests
{
    [TestClass]
    public class MostLikedRecipesStrategyTest
    {
        private Mock<IRecommendationManager> mockRecommendationManager;
        private MostLikedRecipesStrategy strategy;

        [TestInitialize]
        public void SetUp()
        {
            mockRecommendationManager = new Mock<IRecommendationManager>();
            strategy = new MostLikedRecipesStrategy(mockRecommendationManager.Object);
        }

        [TestMethod]
        public void GetRecommendedRecipes_ReturnsTopMostLikedRecipes()
        {
            // Arrange
            var user = new DesktopUser(1, "testUser", "test@example.com", "password", new Role(1, "User"), "Test", "User", 12345, new Gender(1, "Male"), DateTime.Now, "Answer");
            var dietRestriction = new DietRestriction(1, "Vegetarian");
            var difficulty = new Difficulty(1, "Easy");
            var ingredient = new Ingredient(1, "Tomato", new TypeIngredient(1, "Vegetable"));
            var unit = new Unit(1, "kg");
            var ingredientRecipe = new IngredientRecipe(ingredient, 1.5m, unit);
            var ingredients = new List<IngredientRecipe> { ingredientRecipe };
            var expectedRecipes = new List<Recipe>
            {
                new MainCourse(1, "Recipe 1", "Description 1", "Instructions 1", ingredients, user, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20), dietRestriction, difficulty, null, true, 4),
                new MainCourse(2, "Recipe 2", "Description 2", "Instructions 2", ingredients, user, TimeSpan.FromMinutes(15), TimeSpan.FromMinutes(25), dietRestriction, difficulty, null, false, 4),
                new MainCourse(3, "Recipe 3", "Description 3", "Instructions 3", ingredients, user, TimeSpan.FromMinutes(20), TimeSpan.FromMinutes(30), dietRestriction, difficulty, null, true, 4)
            };
            mockRecommendationManager.Setup(m => m.GetTopMostLikedRecipes(3)).Returns(expectedRecipes);

            // Act
            var result = strategy.GetRecommendedRecipes(1);

            // Assert
            Assert.AreEqual(expectedRecipes, result);
        }
    }
}
