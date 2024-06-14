using entity_classes;

namespace manager_classes
{
    public class RecipeSorter
    {
        private IRecipeSortingStrategy sortingStrategy;

        public void SetSortingStrategy(IRecipeSortingStrategy sortingStrategy)
        {
            this.sortingStrategy = sortingStrategy;
        }

        public List<Recipe> SortRecipes(List<Recipe> recipes)
        {
            if (sortingStrategy == null)
            {
                throw new InvalidOperationException("Sorting strategy not set.");
            }
            return sortingStrategy.Sort(recipes);
        }
    }
}