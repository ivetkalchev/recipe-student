using db_helpers;
using entity_classes;
using manager_classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace unit_tests
{
    [TestClass]
    public class SortByRatingTests
    {
        private SortByRating sortByRating;
        private FakeDBReviewHelper reviewHelper;
        private FakeDBRecipeHelper recipeHelper;

        [TestInitialize]
        public void Setup()
        {
            reviewHelper = new FakeDBReviewHelper();
            recipeHelper = new FakeDBRecipeHelper();
            var reviewManager = new ReviewManager(reviewHelper, recipeHelper);
            sortByRating = new SortByRating(reviewManager);

            var recipe1 = new Dessert(1, "Cake", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), null, null, null, false, false);
            var recipe2 = new Dessert(2, "Pie", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(20), TimeSpan.FromMinutes(10), null, null, null, false, false);
            var recipe3 = new Dessert(3, "Cookies", "Description", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(10), null, null, null, false, false);

            recipeHelper.InsertDessert(recipe1);
            recipeHelper.InsertDessert(recipe2);
            recipeHelper.InsertDessert(recipe3);

            reviewHelper.InsertReview(new Review(1, recipe1, 5, "Great!"));
            reviewHelper.InsertReview(new Review(2, recipe1, 5, "Excellent!"));
            reviewHelper.InsertReview(new Review(3, recipe2, 3, "Okay"));
            reviewHelper.InsertReview(new Review(4, recipe3, 4, "Good"));
            reviewHelper.InsertReview(new Review(5, recipe3, 4, "Nice"));
        }

        [TestMethod]
        public void Sort_ReturnsRecipesSortedByRating()
        {
            var recipes = new List<Recipe>
            {
                recipeHelper.GetRecipeById(1),
                recipeHelper.GetRecipeById(2),
                recipeHelper.GetRecipeById(3)
            };

            var sortedRecipes = sortByRating.Sort(recipes);

            Assert.AreEqual(1, sortedRecipes[0].GetIdRecipe());
            Assert.AreEqual(3, sortedRecipes[1].GetIdRecipe());
            Assert.AreEqual(2, sortedRecipes[2].GetIdRecipe());
        }
    }
}
