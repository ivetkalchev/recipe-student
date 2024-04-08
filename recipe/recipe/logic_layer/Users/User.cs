using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer.Users
{
    public class User
    {
        public int Id { get; private set; }
        public string Role { get; private set; }
        public string Username { get; private set; }
        private string hashedPassword;
        private string salt;
        public string Email { get; private set; }
        protected User(int id, string role, string username, string hashedPassword, string salt, string email)
        {
            Id = id;
            Role = role;
            Username = username;
            this.hashedPassword = hashedPassword;
            this.salt = salt;
            Email = email;
        }
        public bool VerifyPassword(string passwordToVerify, IPasswordHasher hasher)
        {
            return hasher.Verify(passwordToVerify, hashedPassword, salt);
        }
    }
}
