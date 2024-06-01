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

namespace recipe_desktop.main_panel_uc
{
    public partial class SingleEmployeeUC : UserControl
    {
        private DesktopUser user;
        private IUserManager userManager;

        public event EventHandler UserDeleted;
        public event EventHandler UserPromoted;

        public SingleEmployeeUC(IUserManager userManager, DesktopUser user)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.user = user;
            LoadUserDetails();
        }

        private void LoadUserDetails()
        {
            SetId(user.GetIdUser());
            SetFirstName(user.GetFirstName());
            SetLastName(user.GetLastName());
            SetUsername(user.GetUsername());
            SetEmail(user.GetEmail());
            SetRole(user.GetRole().GetName());

            btnPromote.Visible = user.GetRole().GetName() != "Admin";
        }

        public void SetId(int id)
        {
            lblId.Text = id.ToString();
        }
        public void SetFirstName(string firstName)
        {
            lblFirstName.Text = firstName;
        }
        public void SetLastName(string lastName)
        {
            lblLastName.Text = lastName;
        }

        public void SetUsername(string username)
        {
            lblUsername.Text = username;
        }

        public void SetEmail(string email)
        {
            lblEmail.Text = email;
        }

        public void SetRole(string role)
        {
            lblRole.Text = role;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            userManager.DeleteUser(user);
            UserDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void btnPromote_Click(object sender, EventArgs e)
        {
            userManager.PromoteUserToAdmin(user);
            UserPromoted?.Invoke(this, EventArgs.Empty);
        }
    }
}