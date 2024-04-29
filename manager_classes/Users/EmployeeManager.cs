using entity_classes.Users;
using entity_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exceptions_classes;
using enum_classes.Users;

namespace manager_classes.Users
{
    public class EmployeeManager
    {
        public void DenyAccess(DesktopUser employee)
        {
            if (employee.GetRole() != Role.Administrator)
            {
                throw new UnauthorizedEmployeeAccessException(employee);
            }
        }
    }
}
