using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes
{
    public class UserProfilePicture
    {
        private string name;
        private byte[] data;
        private string contentType;
        public UserProfilePicture(string name, byte[] data, string contentType)
        {
            this.name = name;
            this.data = data;
            this.contentType = contentType;
        }
        public string GetName()
        {
            return name;
        }
        public byte[] GetData()
        {
            return data;
        }
        public string GetContentType()
        {
            return contentType;
        }
    }
}
