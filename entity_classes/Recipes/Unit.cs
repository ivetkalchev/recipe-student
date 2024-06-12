namespace entity_classes
{
    public class Unit
    {
        private int id;
        private string name;

        public Unit(int id, string name)
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
