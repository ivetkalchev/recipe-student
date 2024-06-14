using entity_classes;
using manager_classes;

namespace unit_tests
{
    [TestClass]
    public class RecipeSorterTests
    {
        private RecipeSorter recipeSorter;

        [TestInitialize]
        public void Setup()
        {
            recipeSorter = new RecipeSorter();
        }

        [TestMethod]
        public void SortRecipes_ByPreparationTime_ReturnsSortedRecipes()
        {
            recipeSorter.SetSortingStrategy(new SortByPreparationTime());

            var recipes = new List<Recipe>
            {
                new Dessert(1, "Cake", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), null, null, null, false, false),
                new Dessert(2, "Pie", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(20), TimeSpan.FromMinutes(10), null, null, null, false, false),
                new Dessert(3, "Cookies", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(10), null, null, null, false, false)
            };

            var sortedRecipes = recipeSorter.SortRecipes(recipes);

            Assert.AreEqual(3, sortedRecipes[0].GetIdRecipe());
            Assert.AreEqual(2, sortedRecipes[1].GetIdRecipe());
            Assert.AreEqual(1, sortedRecipes[2].GetIdRecipe());
        }

        [TestMethod]
        public void SortRecipes_ByTitle_ReturnsSortedRecipes()
        {
            recipeSorter.SetSortingStrategy(new SortByTitle());

            var recipes = new List<Recipe>
            {
                new Dessert(1, "Cake", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), null, null, null, false, false),
                new Dessert(2, "Pie", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(20), TimeSpan.FromMinutes(10), null, null, null, false, false),
                new Dessert(3, "Cookies", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(10), null, null, null, false, false)
            };

            var sortedRecipes = recipeSorter.SortRecipes(recipes);

            Assert.AreEqual(1, sortedRecipes[0].GetIdRecipe());
            Assert.AreEqual(3, sortedRecipes[1].GetIdRecipe());
            Assert.AreEqual(2, sortedRecipes[2].GetIdRecipe());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SortRecipes_NoSortingStrategy_ThrowsInvalidOperationException()
        {
            var recipes = new List<Recipe>
            {
                new Dessert(1, "Cake", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), null, null, null, false, false),
                new Dessert(2, "Pie", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(20), TimeSpan.FromMinutes(10), null, null, null, false, false),
                new Dessert(3, "Cookies", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(10), null, null, null, false, false)
            };

            recipeSorter.SortRecipes(recipes);
        }
    }
}
