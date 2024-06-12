using db_helpers;
using entity_classes;
using System.Collections.Generic;

namespace manager_classes
{
    public class RecipeManager : IRecipeManager
    {
        private readonly IDBRecipeHelper recipeHelper;

        public RecipeManager(IDBRecipeHelper recipeHelper)
        {
            this.recipeHelper = recipeHelper ?? throw new ArgumentNullException(nameof(recipeHelper));
        }

        public List<DietRestriction> GetAllDietRestrictions()
        {
            return recipeHelper.GetAllDietRestrictions();
        }

        public List<Difficulty> GetAllDifficulties()
        {
            return recipeHelper.GetAllDifficulties();
        }

        public DietRestriction GetDietByName(string name)
        {
            return recipeHelper.GetDietByName(name);
        }

        public Difficulty GetDifficultyByName(string name)
        {
            return recipeHelper.GetDifficultyByName(name);
        }

        public void UploadMainCourse(MainCourse recipe)
        {
            recipeHelper.InsertMainCourse(recipe);
        }

        public void UploadDrink(Drink recipe)
        {
            recipeHelper.InsertDrink(recipe);
        }

        public void UploadDessert(Dessert recipe)
        {
            recipeHelper.InsertDessert(recipe);
        }

        public List<Recipe> GetAllRecipes()
        {
            return recipeHelper.GetAllRecipes();
        }

        public Recipe GetRecipeById(int id)
        {
            return recipeHelper.GetRecipeById(id);
        }

        public List<Recipe> GetPagedRecipes(int pageNumber, int pageSize, string searchQuery)
        {
            return recipeHelper.GetPagedRecipes(pageNumber, pageSize, searchQuery);
        }

        public int GetTotalRecipesCount(string searchQuery)
        {
            return recipeHelper.GetTotalRecipesCount(searchQuery);
        }
    }
}
