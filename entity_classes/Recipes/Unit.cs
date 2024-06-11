namespace entity_classes
{
    public class Unit
    {
        private int idUnit;
        private string nameUnit;

        public Unit(int idUnit, string nameUnit)
        {
            IdUnit = idUnit;
            NameUnit = nameUnit;
        }

        public int IdUnit
        {
            get { return idUnit; }
            private set
            {
                idUnit = value; 
            }
        }

        public string NameUnit
        {
            get { return  nameUnit; }
            private set
            {
                nameUnit = value;
            }
        }
    }
}
