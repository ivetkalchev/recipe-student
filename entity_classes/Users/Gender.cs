namespace entity_classes
{
    public class Gender
    {
        private int id;
        private string name;

        public Gender(int id, string name)
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