using entity_classes;

namespace manager_classes
{
    public interface IRecipeManager
    {
        List<DietRestriction> GetAllDietRestrictions();
        List<Difficulty> GetAllDifficulties();
        DietRestriction GetDietByName(string name);
        Difficulty GetDifficultyByName(string name);
        void SaveRecipe(MainCourse mainCourse);
    }
}