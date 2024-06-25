using db_helpers;
using entity_classes;
using System.Collections.Generic;

namespace unit_tests
{
    public class FakeDBRecipeHelper : IDBRecipeHelper
    {
        private List<Recipe> recipes = new List<Recipe>();
        private List<DietRestriction> dietRestrictions = new List<DietRestriction>();
        private List<Difficulty> difficulties = new List<Difficulty>();

        public List<DietRestriction> GetAllDietRestrictions()
        {
            return dietRestrictions;
        }

        public List<Difficulty> GetAllDifficulties()
        {
            return difficulties;
        }

        public DietRestriction GetDietByName(string name)
        {
            return dietRestrictions.Find(d => d.GetName() == name);
        }

        public Difficulty GetDifficultyByName(string name)
        {
            return difficulties.Find(d => d.GetName() == name);
        }

        public void InsertMainCourse(MainCourse recipe)
        {
            recipes.Add(recipe);
        }

        public void InsertDrink(Drink recipe)
        {
            recipes.Add(recipe);
        }

        public void InsertDessert(Dessert recipe)
        {
            recipes.Add(recipe);
        }

        public List<Recipe> GetAllRecipes()
        {
            return recipes;
        }

        public Recipe GetRecipeById(int id)
        {
            return recipes.Find(r => r.GetIdRecipe() == id);
        }

        public List<Recipe> GetPagedRecipes(int pageNumber, int pageSize, string searchQuery, string sortOption)
        {
            return new List<Recipe>();
        }

        public int GetTotalRecipesCount(string searchQuery)
        {
            return recipes.Count;
        }

        public void DeleteRecipe(int recipeId)
        {
            recipes.RemoveAll(r => r.GetIdRecipe() == recipeId);
        }

        public void UpdateDrink(Drink drink) { }

        public void UpdateDessert(Dessert dessert) { }

        public void UpdateMainCourse(MainCourse mainCourse) { }

        public void InsertIngredientToRecipe(int recipeId, int ingredientId, int unitId, decimal quantity) { }

        public void DeleteIngredientFromRecipe(int recipeId, int ingredientId) { }

        public DietRestriction GetDietRestrictionById(int id)
        {
            return dietRestrictions.Find(d => d.GetId() == id);
        }

        public Difficulty GetDifficultyById(int id)
        {
            return difficulties.Find(d => d.GetId() == id);
        }

        public void AddDietRestriction(DietRestriction dietRestriction)
        {
            dietRestrictions.Add(dietRestriction);
        }

        public void AddDifficulty(Difficulty difficulty)
        {
            difficulties.Add(difficulty);
        }
    }
}