using entity_classes.Users;
using entity_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enum_classes;

namespace manager_classes
{
    public class EmployeeManager
    {
        public void DenyAccess(DesktopUser employee)
        {
            if (employee.GetRole() != Role.Administrator)
            {
                throw new UnauthorizedAccessException("Access Denied: You do not have permission to manage employees.");
            }
        }
    }
}
