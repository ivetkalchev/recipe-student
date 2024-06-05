namespace entity_classes
{
    public class Difficulty
    {
        private int id;
        private string name;

        public Difficulty(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int GetIdDifficulty()
        {
            return id;
        }
        public string GetName()
        {
            return name;
        }
    }
}
