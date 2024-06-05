using entity_classes;

namespace db_helpers
{
    public interface IDBRecipeHelper
    {
        List<DietRestriction> GetAllDietRestrictions();
        List<Difficulty> GetAllDifficulties();
        DietRestriction GetDietByName(string name);
        Difficulty GetDifficultyByName(string name);
        void InsertMainCourse(MainCourse recipe);
        void InsertDrink(Drink recipe);
        void InsertDessert(Dessert recipe);
    }
}
