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
        Recipe GetRecipeById(int id);
        void UploadDessert(Dessert recipe);
        void UploadDrink(Drink recipe);
        void UploadMainCourse(MainCourse recipe);
    }
}