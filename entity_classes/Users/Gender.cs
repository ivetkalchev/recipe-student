namespace entity_classes
{
    public class Gender
    {
        private int idGender;
        private string nameGender;

        public Gender(int idGender, string nameGender)
        {
            IdGender = idGender;
            NameGender = nameGender;
        }

        public int IdGender
        {
            get { return  idGender; }
            private set
            {
                idGender = value;
            }
        }

        public string NameGender
        {
            get { return nameGender; }
            private set
            {
                nameGender = value;
            }
        }
    }
}
