using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public class User
    {
        private int id;
        private string role;
        private string username;
        private string password;
        private string hasshedPassword;
        private string salt;
        private string email;
        protected User(int id, string role, string username, string password, string hashedPassword, string salt, string email)
        {
            this.id = id;
            this.role = role;
            this.username = username;
            this.hasshedPassword = hashedPassword;
            this.salt = salt;
            this.password = password;
            this.email = email;
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
