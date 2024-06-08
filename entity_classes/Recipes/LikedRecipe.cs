namespace entity_classes
{
    public class ToDoList
    {
        private WebUser user;
        private Recipe recipe;

        public ToDoList(WebUser user, Recipe recipe)
        {
            this.user = user;
            this.recipe = recipe;
        }

        public WebUser GetWebUser()
        {
            return user;
        }

        public Recipe GetRecipe()
        {
            return recipe;
        }
    }
}
