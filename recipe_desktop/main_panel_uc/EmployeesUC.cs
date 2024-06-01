using System;
using System.Collections.Generic;
using System.Windows.Forms;
using entity_classes;
using manager_classes;
using recipe_desktop.main_panel_uc;

namespace recipe_desktop
{
    public partial class EmployeesUC : UserControl
    {
        private IUserManager userManager;
        private List<DesktopUser> users;
        private int currentPage;
        private int totalPages;
        private const int UsersPerPage = 5;

        public EmployeesUC(IUserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            currentPage = 1;
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            users = userManager.GetAllDesktopUsers();
            totalPages = (int)Math.Ceiling(users.Count / (double)UsersPerPage);
            DisplayUsers();
        }

        private void DisplayUsers()
        {
            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown
            };

            int startIndex = (currentPage - 1) * UsersPerPage;
            int endIndex = Math.Min(startIndex + UsersPerPage, users.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                SingleEmployeeUC employee = new SingleEmployeeUC(userManager, users[i]);
                employee.UserDeleted += Employee_UserDeleted;
                employee.UserPromoted += Employee_UserPromoted;

                employee.Margin = new Padding(0, 0, 0, 10);

                flowPanel.Controls.Add(employee);
            }

            panelEmployee.Controls.Clear();
            panelEmployee.Controls.Add(flowPanel);

            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void Employee_UserDeleted(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void Employee_UserPromoted(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayUsers();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                DisplayUsers();
            }
        }
    }
}
