namespace entity_classes
{
    public class DietRestriction
    {
        private int idDietRestriction;
        private string nameDietRestriction;

        public DietRestriction(int idDietRestriction, string nameDietRestriction)
        {
            IdDietRestriction = idDietRestriction;
            NameDietRestriction = nameDietRestriction;
        }
        public int IdDietRestriction
        {
            get { return idDietRestriction; }
            private set { idDietRestriction = value; }
        }
        public string NameDietRestriction
        {
            get { return nameDietRestriction; }
            private set { nameDietRestriction = value; }
        }
    }
}
