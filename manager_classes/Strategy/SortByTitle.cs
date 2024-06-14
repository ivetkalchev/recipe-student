using entity_classes;

namespace manager_classes
{
    public class SortByTitle : IRecipeSortingStrategy
    {
        public List<Recipe> Sort(List<Recipe> recipes)
        {
            recipes.Sort(new Comparison<Recipe>(CompareByTitle));
            return recipes;
        }

        private int CompareByTitle(Recipe x, Recipe y)
        {
            return string.Compare(x.GetTitle(), y.GetTitle());
        }
    }
}
