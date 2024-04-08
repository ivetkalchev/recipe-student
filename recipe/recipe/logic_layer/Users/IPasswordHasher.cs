using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer.Users
{
    public interface IPasswordHasher
    {
        bool Verify(string passwordToVerify, string hashedPassword, string salt);
    }
}
