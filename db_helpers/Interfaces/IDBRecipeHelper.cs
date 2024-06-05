using entity_classes;

namespace db_helpers
{
    public interface IDBRecipeHelper
    {
        List<DietRestriction> GetAllDietRestrictions();
        List<Difficulty> GetAllDifficulties();
        DietRestriction GetDietByName(string name);
        Difficulty GetDifficultyByName(string name);
        void SaveMainCourse(MainCourse mainCourse);
    }
}
