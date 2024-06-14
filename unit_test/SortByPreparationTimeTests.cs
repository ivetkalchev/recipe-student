using entity_classes;
using manager_classes;

namespace unit_tests
{
    [TestClass]
    public class SortByPreparationTimeTests
    {
        private SortByPreparationTime sortByPreparationTime;

        [TestInitialize]
        public void Setup()
        {
            sortByPreparationTime = new SortByPreparationTime();
        }

        [TestMethod]
        public void Sort_ReturnsRecipesSortedByPreparationTime()
        {
            var recipes = new List<Recipe>
            {
                new Dessert(1, "Cake", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), null, null, null, false, false),
                new Dessert(2, "Pie", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(20), TimeSpan.FromMinutes(10), null, null, null, false, false),
                new Dessert(3, "Cookies", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(10), null, null, null, false, false)
            };

            var sortedRecipes = sortByPreparationTime.Sort(recipes);

            Assert.AreEqual(3, sortedRecipes[0].GetIdRecipe());
            Assert.AreEqual(2, sortedRecipes[1].GetIdRecipe());
            Assert.AreEqual(1, sortedRecipes[2].GetIdRecipe());
        }
    }
}