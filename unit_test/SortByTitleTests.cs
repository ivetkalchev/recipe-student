using entity_classes;
using manager_classes;

namespace unit_tests
{
    [TestClass]
    public class SortByTitleTests
    {
        private SortByTitle sortByTitle;

        [TestInitialize]
        public void Setup()
        {
            sortByTitle = new SortByTitle();
        }

        [TestMethod]
        public void Sort_ReturnsRecipesSortedByTitle()
        {
            var recipes = new List<Recipe>
            {
                new Dessert(1, "Cake", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), null, null, null, false, false),
                new Dessert(2, "Pie", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(20), TimeSpan.FromMinutes(10), null, null, null, false, false),
                new Dessert(3, "Cookies", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(10), null, null, null, false, false)
            };

            var sortedRecipes = sortByTitle.Sort(recipes);

            Assert.AreEqual(1, sortedRecipes[0].GetIdRecipe());
            Assert.AreEqual(3, sortedRecipes[1].GetIdRecipe());
            Assert.AreEqual(2, sortedRecipes[2].GetIdRecipe());
        }
    }
}
