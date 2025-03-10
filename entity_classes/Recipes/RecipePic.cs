﻿namespace entity_classes
{
    public class RecipePic
    {
        private int idRecipePic;
        private string name;
        private string data;
        private string contentType;

        public RecipePic(int idRecipePic, string name, string data, string contentType)
        {
            this.idRecipePic = idRecipePic;
            this.name = name;
            this.data = data;
            this.contentType = contentType;
        }
        public string GetName()
        {
            return name;
        }

        public string GetData()
        {
            return data;
        }

        public string GetContentType()
        {
            return contentType;
        }
    }
}
