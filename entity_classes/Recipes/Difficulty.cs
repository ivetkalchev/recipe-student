namespace entity_classes
{
    public class Difficulty
    {
        private int idDifficulty;
        private string nameDifficulty;

        public Difficulty(int idDifficulty, string nameDifficulty)
        {
            IdDifficulty = idDifficulty;
            NameDifficulty = nameDifficulty;
        }
        public int IdDifficulty
        {
            get { return idDifficulty; }
            private set { idDifficulty = value; }
        }

        public string NameDifficulty
        {
            get { return nameDifficulty; }
            private set { nameDifficulty = value; }
        }
    }
}
