using DTOs;
using entity_classes.Recipes;
using entity_classes.Users;
using enum_classes.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager_classes
{
    public class MappingProfile
    {
        public User MapDesktopUserToUser(DesktopUserDTO desktopUser)
        {
            return new DesktopUser(
                desktopUser.IdUser,
                desktopUser.Username,
                desktopUser.Email,
                desktopUser.Password,
                Role.Employee,
                desktopUser.FirstName,
                desktopUser.LastName,
                desktopUser.Bsn,
                Gender.Male,
                desktopUser.Birthdate,
                desktopUser.SecurityAnswer,
                new List<Recipe>()
            ); ;
        }
        public User MapWebUserToUser(WebUserDTO webUser)
        {
            return new WebUser(
                webUser.IdUser,
                webUser.Username,
                webUser.Email,
                webUser.Password,
                webUser.Caption,
                new List<Recipe>()
            );
        }
    }
}
