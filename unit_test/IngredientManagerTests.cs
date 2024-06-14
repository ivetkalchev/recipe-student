using db_helpers;
using entity_classes;
using exceptions;
using manager_classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace unit_tests
{
    [TestClass]
    public class IngredientManagerTests
    {
        private IngredientManager ingredientManager;
        private FakeDBIngredientHelper fakeDBIngredientHelper;

        [TestInitialize]
        public void Setup()
        {
            fakeDBIngredientHelper = new FakeDBIngredientHelper();
            ingredientManager = new IngredientManager(fakeDBIngredientHelper);
        }

        [TestMethod]
        public void AddIngredient_ShouldAddIngredient_WhenIngredientDoesNotExist()
        {
            var ingredient = new Ingredient(1, "Sugar", new TypeIngredient(1, "Sweetener"));
            ingredientManager.AddIngredient(ingredient);

            var ingredients = ingredientManager.GetAllIngredients();
            Assert.AreEqual(1, ingredients.Count);
            Assert.AreEqual("Sugar", ingredients[0].GetName());
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistIngredientException))]
        public void AddIngredient_ShouldThrowException_WhenIngredientAlreadyExists()
        {
            var ingredient = new Ingredient(1, "Sugar", new TypeIngredient(1, "Sweetener"));
            fakeDBIngredientHelper.AddIngredient(ingredient);

            var newIngredient = new Ingredient(2, "Sugar", new TypeIngredient(1, "Sweetener"));
            ingredientManager.AddIngredient(newIngredient);
        }

        [TestMethod]
        public void GetAllTypeIngredients_ShouldReturnAllTypeIngredients()
        {
            var typeIngredients = ingredientManager.GetAllTypeIngredients();
            Assert.IsNotNull(typeIngredients);
        }

        [TestMethod]
        public void GetTypeIngredientByName_ShouldReturnTypeIngredient_WhenTypeExists()
        {
            var type = new TypeIngredient(1, "Sweetener");
            fakeDBIngredientHelper.AddType(type);

            var result = ingredientManager.GetTypeIngredientByName("Sweetener");
            Assert.IsNotNull(result);
            Assert.AreEqual("Sweetener", result.GetName());
        }
    }
}
