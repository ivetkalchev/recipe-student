using System;
using System.Collections.Generic;

namespace entity_classes
{
    public class Role
    {
        private int id;
        private string name;
        public Role(int id, string name)
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
