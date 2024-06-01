using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string GetName()
        {
            return name;
        }
    }
}
