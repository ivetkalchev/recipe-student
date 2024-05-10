using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProfilePicDTO : UserDTO
    {
        public string ImagePath { get; set; }
        public string ImageType { get; set; }
    }
}
