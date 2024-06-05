﻿namespace entity_classes
{
    public class DietRestriction
    {
        private int id;
        private string name;

        public DietRestriction(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int GetIdDietRestriction()
        {
            return id;
        }
        public string GetName()
        {
            return name;
        }
    }
}
