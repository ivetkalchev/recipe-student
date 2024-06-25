using entity_classes;
using manager_classes;

namespace unit_tests
{
    [TestClass]
    public class RecipeRecommendationServiceTests
    {
        private RecipeRecommendationService recommendationService;
        private FakeDBRecipeHelper recipeHelper;
        private FakeDBReviewHelper reviewHelper;
        private FakeDBToDoListHelper toDoListHelper;
        private FakeDBRecommendationHelper recommendationHelper;

        private IRecipeManager recipeManager;
        private IReviewManager reviewManager;

        [TestInitialize]
        public void Setup()
        {
            recipeHelper = new FakeDBRecipeHelper();
            reviewHelper = new FakeDBReviewHelper();
            toDoListHelper = new FakeDBToDoListHelper();

            recipeManager = new RecipeManager(recipeHelper);
            reviewManager = new ReviewManager(reviewHelper, recipeHelper);
            recommendationHelper = new FakeDBRecommendationHelper(recipeManager);

            var toDoListManager = new ToDoListManager(toDoListHelper);
            recommendationService = new RecipeRecommendationService(recipeManager, toDoListManager, reviewManager, recommendationHelper);

            SetupFakeData();
        }

        private void SetupFakeData()
        {
            var dietRestriction1 = new DietRestriction(1, "None");
            var dietRestriction2 = new DietRestriction(2, "Gluten-Free");
            recipeHelper.AddDietRestriction(dietRestriction1);
            recipeHelper.AddDietRestriction(dietRestriction2);

            var difficulty1 = new Difficulty(1, "Easy");
            var difficulty2 = new Difficulty(2, "Medium");
            recipeHelper.AddDifficulty(difficulty1);
            recipeHelper.AddDifficulty(difficulty2);

            var dessert1 = new Dessert(1, "Cake", "Delicious cake", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), dietRestriction1, difficulty1, null, false, false);
            var dessert2 = new Dessert(2, "Pie", "Tasty pie", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(20), TimeSpan.FromMinutes(10), dietRestriction1, difficulty1, null, false, false);
            var dessert3 = new Dessert(3, "Cookies", "Yummy cookies", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(10), dietRestriction1, difficulty1, null, false, false);
            var dessert4 = new Dessert(4, "Brownies", "Delicious brownies", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(40), TimeSpan.FromMinutes(20), dietRestriction2, difficulty2, null, false, false);

            recipeHelper.InsertDessert(dessert1);
            recipeHelper.InsertDessert(dessert2);
            recipeHelper.InsertDessert(dessert3);
            recipeHelper.InsertDessert(dessert4);

            reviewHelper.InsertReview(new Review(1, dessert1, 5, "Great!"));
            reviewHelper.InsertReview(new Review(2, dessert1, 5, "Excellent!"));
            reviewHelper.InsertReview(new Review(3, dessert2, 3, "Okay"));
            reviewHelper.InsertReview(new Review(4, dessert2, 4, "Good"));
            reviewHelper.InsertReview(new Review(5, dessert3, 4, "Nice"));
            reviewHelper.InsertReview(new Review(6, dessert3, 5, "Awesome"));
            reviewHelper.InsertReview(new Review(7, dessert4, 4, "Tasty"));
            reviewHelper.InsertReview(new Review(8, dessert4, 5, "Amazing"));

            recommendationHelper.AddUserLikedRecipe(1, 1);
            recommendationHelper.AddUserLikedRecipe(1, 3);
            recommendationHelper.AddUserSimilarities(1, new List<int> { 2, 3 });
            recommendationHelper.AddUserLikedRecipe(2, 2);
            recommendationHelper.AddUserLikedRecipe(2, 4);
            recommendationHelper.AddUserLikedRecipe(3, 2);
            recommendationHelper.AddUserLikedRecipe(3, 4);
        }


        [TestMethod]
        public void GetMostPopularRecipes_ReturnsTopFourRecipes()
        {
            var popularRecipes = recommendationService.GetMostPopularRecipes();

            Assert.AreEqual(4, popularRecipes.Count);

            var recipeReviewCounts = new Dictionary<int, int>();
            foreach (var recipe in popularRecipes)
            {
                int reviewCount = reviewManager.GetReviewsByRecipeId(recipe.GetIdRecipe()).Count;
                recipeReviewCounts.Add(recipe.GetIdRecipe(), reviewCount);
            }

            var expectedReviewCounts = new List<int> { 2, 2, 2, 2 };
            var actualReviewCounts = new List<int>(recipeReviewCounts.Values);

            for (int i = 0; i < expectedReviewCounts.Count; i++)
            {
                Assert.AreEqual(expectedReviewCounts[i], actualReviewCounts[i]);
            }
        }


        [TestMethod]
        public void GetRecommendedRecipes_ReturnsSimilarRecipes_WhenToDoListIsNotEmpty()
        {
            var userId = 1;

            var recommendedRecipes = recommendationService.GetRecommendedRecipes(userId);

            Assert.AreEqual(2, recommendedRecipes.Count);

            var expectedRecipeIds = new List<int> { 2, 4 };
            for (int i = 0; i < recommendedRecipes.Count; i++)
            {
                Assert.AreEqual(expectedRecipeIds[i], recommendedRecipes[i].GetIdRecipe());
            }
        }
    }
}