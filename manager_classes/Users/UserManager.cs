using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Users;

namespace manager_classes.Users
{
    public class UserManager
    {
        private List<User> users = new List<User>();
        public void CreateUser(User user)
        {
            users.Add(user);
        }
        public void DeleteUser(User user)
        {
            users.Remove(user);
        }
        public void EditUser(User user, string updatedUsername, string updatedEmail)
        {
            user.SetUsername(updatedUsername);
            user.SetEmail(updatedEmail);
        }
        public void ChangePassword(User user, string updatedPassword)
        {
            user.SetPassword(updatedPassword);
        }
    }
}
