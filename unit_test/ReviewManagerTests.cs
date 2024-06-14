using db_helpers;
using entity_classes;
using manager_classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace unit_tests
{
    [TestClass]
    public class ReviewManagerTests
    {
        private ReviewManager reviewManager;
        private FakeDBReviewHelper fakeDBReviewHelper;
        private FakeDBRecipeHelper fakeDBRecipeHelper;

        [TestInitialize]
        public void Setup()
        {
            fakeDBReviewHelper = new FakeDBReviewHelper();
            fakeDBRecipeHelper = new FakeDBRecipeHelper();
            reviewManager = new ReviewManager(fakeDBReviewHelper, fakeDBRecipeHelper);
        }

        [TestMethod]
        public void AddReview_ShouldAddReview()
        {
            var recipe = new Dessert(1, "Cake", "Delicious cake", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), null, null, null, false, false);
            fakeDBRecipeHelper.InsertDessert(recipe);

            var review = new Review(1, recipe, 5, "Great!");
            reviewManager.AddReview(review);

            var reviews = reviewManager.GetReviewsByRecipeId(1);
            Assert.AreEqual(1, reviews.Count);
            Assert.AreEqual("Great!", reviews[0].GetReviewText());
        }

        [TestMethod]
        public void GetReviewsByRecipeId_ShouldReturnReviews()
        {
            var recipe = new Dessert(1, "Cake", "Delicious cake", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), null, null, null, false, false);
            fakeDBRecipeHelper.InsertDessert(recipe);

            var review = new Review(1, recipe, 5, "Great!");
            fakeDBReviewHelper.InsertReview(review);

            var reviews = reviewManager.GetReviewsByRecipeId(1);
            Assert.IsNotNull(reviews);
            Assert.AreEqual(1, reviews.Count);
            Assert.AreEqual("Great!", reviews[0].GetReviewText());
        }

        [TestMethod]
        public void GetReviewById_ShouldReturnReview_WhenReviewExists()
        {
            var recipe = new Dessert(1, "Cake", "Delicious cake", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), null, null, null, false, false);
            fakeDBRecipeHelper.InsertDessert(recipe);

            var review = new Review(1, recipe, 5, "Great!");
            fakeDBReviewHelper.InsertReview(review);

            var result = reviewManager.GetReviewById(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("Great!", result.GetReviewText());
        }

        [TestMethod]
        public void DeleteReview_ShouldRemoveReview()
        {
            var recipe = new Dessert(1, "Cake", "Delicious cake", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), null, null, null, false, false);
            fakeDBRecipeHelper.InsertDessert(recipe);

            var review = new Review(1, recipe, 5, "Great!");
            fakeDBReviewHelper.InsertReview(review);

            reviewManager.DeleteReview(1);
            var reviews = reviewManager.GetReviewsByRecipeId(1);
            Assert.AreEqual(0, reviews.Count);
        }
    }
}
