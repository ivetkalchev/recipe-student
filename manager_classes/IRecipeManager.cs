using entity_classes;

namespace manager_classes
{
    public interface IRecipeManager
    {
        List<DietRestriction> GetAllDietRestrictions();
        List<Difficulty> GetAllDifficulties();
        DietRestriction GetDietByName(string name);
        Difficulty GetDifficultyByName(string name);
        void UploadDessert(Dessert recipe);
        void UploadDrink(Drink recipe);
        void UploadMainCourse(MainCourse recipe);
    }
}