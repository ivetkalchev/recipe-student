using entity_classes;

namespace manager_classes
{
    public interface IRecipeSortingStrategy
    {
        List<Recipe> Sort(List<Recipe> recipes);
    }
}
