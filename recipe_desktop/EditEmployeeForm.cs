using entity_classes;
using manager_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class EditEmployeeForm : Form
    {
        private DesktopUser user;
        private IUserManager userManager;

        public EditEmployeeForm(IUserManager userManager, DesktopUser user)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.user = user;
        }
    }
}
