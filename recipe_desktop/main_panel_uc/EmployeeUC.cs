using entity_classes;
using manager_classes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class EmployeeUC : UserControl
    {
        private IUserManager userManager;

        private int currentPage;
        private int totalPages;
        
        private const int UsersPerPage = 5;
        
        private string currentFilter = "All";
        
        private List<DesktopUser> users;
        private List<DesktopUser> searchResults;

        public EmployeeUC(IUserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;

            currentPage = 1;

            LoadEmployees();
        }

        private void LoadEmployees()
        {
            users = userManager.GetAllDesktopUsers();
            ApplyFilterAndPagination();
        }

        private void ApplyFilterAndPagination()
        {
            List<DesktopUser> filteredUsers = searchResults ?? FilterUsers(users, currentFilter);
            totalPages = (int)Math.Ceiling(filteredUsers.Count / (double)UsersPerPage);
            DisplayUsers(filteredUsers);
        }

        private void DisplayUsers(List<DesktopUser> usersToDisplay)
        {
            panelEmployee.Controls.Clear();

            lblNoResults.Visible = usersToDisplay.Count == 0;

            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown
            };

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

            panelEmployee.Controls.Add(flowPanel);

            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private List<DesktopUser> FilterUsers(List<DesktopUser> users, string filter)
        {
            List<DesktopUser> filteredUsers = new List<DesktopUser>();

            foreach (DesktopUser user in users)
            {
                if (filter == "Admins" && user.Role.NameRole == "Admin")
                {
                    filteredUsers.Add(user);
                }
                else if (filter == "Employees" && user.Role.NameRole == "Employee")
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
                if (user.FirstName.ToLower().Contains(lowerQuery) || user.LastName.ToLower().Contains(lowerQuery))
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
                ApplyFilterAndPagination();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                ApplyFilterAndPagination();
            }
        }

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            currentFilter = "Admins";
            currentPage = 1;
            searchResults = null;
            ApplyFilterAndPagination();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            currentFilter = "Employees";
            currentPage = 1;
            searchResults = null;
            ApplyFilterAndPagination();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            currentFilter = "All";
            currentPage = 1;
            searchResults = null;
            ApplyFilterAndPagination();
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            string query = tbSearch.Text.Trim();
            if (!string.IsNullOrEmpty(query))
            {
                searchResults = SearchUsers(query);
            }
            else
            {
                searchResults = null;
            }
            currentPage = 1;
            ApplyFilterAndPagination();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                picSearch_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
