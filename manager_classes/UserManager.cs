using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Users;

namespace manager_classes
{
    public class UserManager
    {
        private List<User> users;
        public UserManager()
        {
            users = new List<User>();
        }

        public void CreateUser(User user)
        {
            users.Add(user);
        }

        public void FireUser(User user)
        {
            users.Remove(user);
        }

        public List<User> GetAllUsers()
        {
            return users;
        }
        public List<User> GetAllWebUsers()
        {
            List<User> webUsers = new List<User>();
            foreach (User user in users)
            {
                if (user is WebUser)
                {
                    webUsers.Add(user);
                }
            }
            return webUsers;
        }
        public List<User> GetAllDesktopUsers()
        {
            List<User> desktopUsers = new List<User>();
            foreach (User user in users)
            {
                if (user is DesktopUser)
                {
                    desktopUsers.Add(user);
                }
            }
            return desktopUsers;
        }
    }
}
