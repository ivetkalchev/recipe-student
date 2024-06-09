using entity_classes;

namespace manager_classes
{
    public interface IRecipeManager
    {
        List<DietRestriction> GetAllDietRestrictions();
        List<Difficulty> GetAllDifficulties();
        List<Recipe> GetAllRecipes();
        DietRestriction GetDietByName(string name);
        Difficulty GetDifficultyByName(string name);
        List<Recipe> GetPagedRecipes(int pageNumber, int pageSize, string searchQuery);
        Recipe GetRecipeById(int id);
        int GetTotalRecipesCount(string searchQuery);
        void UploadDessert(Dessert recipe);
        void UploadDrink(Drink recipe);
        void UploadMainCourse(MainCourse recipe);
    }
}