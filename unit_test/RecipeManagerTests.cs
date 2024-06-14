using db_helpers;
using entity_classes;
using manager_classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace unit_tests
{
    [TestClass]
    public class RecipeManagerTests
    {
        private RecipeManager recipeManager;
        private FakeDBRecipeHelper fakeDBRecipeHelper;

        [TestInitialize]
        public void Setup()
        {
            fakeDBRecipeHelper = new FakeDBRecipeHelper();
            recipeManager = new RecipeManager(fakeDBRecipeHelper);
        }

        [TestMethod]
        public void UploadDessert_ShouldAddDessert()
        {
            var dessert = new Dessert(1, "Cake", "Delicious cake", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), null, null, null, false, false);
            recipeManager.UploadDessert(dessert);

            var recipes = recipeManager.GetAllRecipes();
            Assert.AreEqual(1, recipes.Count);
            Assert.AreEqual("Cake", recipes[0].GetTitle());
        }

        [TestMethod]
        public void GetRecipeById_ShouldReturnRecipe_WhenRecipeExists()
        {
            var dessert = new Dessert(1, "Cake", "Delicious cake", "Instructions", new List<IngredientRecipe>(), null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(10), null, null, null, false, false);
            fakeDBRecipeHelper.InsertDessert(dessert);

            var recipe = recipeManager.GetRecipeById(1);
            Assert.IsNotNull(recipe);
            Assert.AreEqual("Cake", recipe.GetTitle());
        }
    }
}
