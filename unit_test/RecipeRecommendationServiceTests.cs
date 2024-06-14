using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using entity_classes;
using manager_classes;
using db_helpers;

namespace unit_tests
{
    [TestClass]
    public class RecipeRecommendationServiceTests
    {
        private RecipeRecommendationService recommendationService;
        private FakeDBRecipeHelper recipeHelper;
        private FakeDBReviewHelper reviewHelper;
        private FakeDBToDoListHelper toDoListHelper;

        [TestInitialize]
        public void Setup()
        {
            recipeHelper = new FakeDBRecipeHelper();
            reviewHelper = new FakeDBReviewHelper();
            toDoListHelper = new FakeDBToDoListHelper();

            var recipeManager = new RecipeManager(recipeHelper);
            var reviewManager = new ReviewManager(reviewHelper, recipeHelper);
            var toDoListManager = new ToDoListManager(toDoListHelper);
            recommendationService = new RecipeRecommendationService(recipeManager, toDoListManager, reviewManager);

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
            reviewHelper.InsertReview(new Review(4, dessert3, 4, "Good"));
            reviewHelper.InsertReview(new Review(5, dessert3, 4, "Nice"));
        }

        [TestMethod]
        public void GetRecommendedRecipes_ReturnsSimilarRecipes_WhenToDoListIsNotEmpty()
        {
            var userId = 1;
            toDoListHelper.AddToDoList(userId, 1);
            toDoListHelper.AddToDoList(userId, 3);

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
