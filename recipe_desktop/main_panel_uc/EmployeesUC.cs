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
        private string currentFilter = "All";
        private List<DesktopUser> searchResults;

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

            List<DesktopUser> usersToDisplay = searchResults ?? FilterUsers(users, currentFilter);

            int startIndex = (currentPage - 1) * UsersPerPage;
            int endIndex = Math.Min(startIndex + UsersPerPage, usersToDisplay.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                SingleEmployeeUC employee = new SingleEmployeeUC(userManager, usersToDisplay[i]);
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

        private List<DesktopUser> FilterUsers(List<DesktopUser> users, string filter)
        {
            List<DesktopUser> filteredUsers = new List<DesktopUser>();

            foreach (DesktopUser user in users)
            {
                if (filter == "Admins" && user.GetRole().GetName() == "Admin")
                {
                    filteredUsers.Add(user);
                }
                else if (filter == "Employees" && user.GetRole().GetName() == "Employee")
                {
                    filteredUsers.Add(user);
                }
                else if (filter == "All")
                {
                    filteredUsers.Add(user);
                }
            }

            return filteredUsers;
        }

        private List<DesktopUser> SearchUsers(string query)
        {
            List<DesktopUser> searchResults = new List<DesktopUser>();
            string lowerQuery = query.ToLower();

            foreach (DesktopUser user in users)
            {
                if (user.GetFirstName().ToLower().Contains(lowerQuery) || user.GetLastName().ToLower().Contains(lowerQuery))
                {
                    searchResults.Add(user);
                }
            }

            return searchResults;
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

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            currentFilter = "Admins";
            currentPage = 1;
            searchResults = null;
            LoadEmployees();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            currentFilter = "Employees";
            currentPage = 1;
            searchResults = null;
            LoadEmployees();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            currentFilter = "All";
            currentPage = 1;
            searchResults = null;
            LoadEmployees();
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            string query = tbSearch.Text.Trim();
            if (!string.IsNullOrEmpty(query))
            {
                searchResults = SearchUsers(query);
                currentPage = 1;
                DisplayUsers();
            }
            else
            {
                searchResults = null;
                DisplayUsers();
            }
        }
    }
}
