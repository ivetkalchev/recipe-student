namespace entity_classes
{
    public class Role
    {
        private int idRole;
        private string nameRole;

        public Role(int idRole, string nameRole)
        {
            IdRole = idRole;
            NameRole = nameRole;
        }

        public int IdRole
        {
            get {  return idRole; }
            private set { idRole = value; }
        }

        public string NameRole
        {
            get { return  nameRole; }
            private set { nameRole = value; }
        }
    }
}
