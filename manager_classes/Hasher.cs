using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes
{
    public static class Hasher
    {
        public static string HashText(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha256.ComputeHash(textBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
