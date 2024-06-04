namespace entity_classes
{
    public class TypeIngredient
    {
        private int id;
        private string name;

        public TypeIngredient(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int GetId()
        {
            return id;
        }
        public string GetName()
        {
            return name;
        }
    }
}
