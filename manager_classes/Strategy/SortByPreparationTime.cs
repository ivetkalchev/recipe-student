using entity_classes;

namespace manager_classes
{
    public class SortByPreparationTime : IRecipeSortingStrategy
    {
        public List<Recipe> Sort(List<Recipe> recipes)
        {
            recipes.Sort(new Comparison<Recipe>(CompareByPreparationTime));
            return recipes;
        }

        private int CompareByPreparationTime(Recipe x, Recipe y)
        {
            return x.GetPreparationTime().CompareTo(y.GetPreparationTime());
        }
    }
}
