using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes
{
    public class RecipePic
    {
        private int idRecipePic;
        private string namePic;
        private string dataPic;
        private string contentTypePic;

        public RecipePic(int idRecipePic, string namePic, string dataPic, string contentTypePic)
        {
            IdRecipePic = idRecipePic;
            NamePic = namePic;
            DataPic = dataPic;
            ContentTypePic = contentTypePic;
        }

        public int IdRecipePic
        {
            get { return idRecipePic; } 
            private set { idRecipePic = value; }
        }

        public string NamePic
        {
            get { return namePic; }
            private set { namePic = value; }
        }

        public string DataPic
        {
            get { return  dataPic; }
            private set { dataPic = value; }
        }

        public string ContentTypePic
        {
            get { return contentTypePic; }
            private set { contentTypePic = value; }
        }
    }
}
