using entity_classes;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using manager_classes;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LiveChartsCore.SkiaSharpView.WinForms;

namespace recipe_desktop
{
    public partial class DashBoardUC : UserControl
    {
        private IUserManager userManager;
        public DashBoardUC(IUserManager userManager, DesktopUser user)
        {
            InitializeComponent();
            this.userManager = userManager;

            lblWelcomeUser.Text = $"Welcome, {user.GetFirstName()} {user.GetLastName()}!";

            SetGuideText(user.GetRole().GetName());

            LoadPieChart();
        }

        private void SetGuideText(string roleName)
        {
            if (roleName == "Admin")
            {
                lblGuide.Text = "Here is a little guide on how to use the application as an Admin:\n" +
                                "Dashboard: The Dashboard section provides an overview of statistics, related to the application, \n" +
                                "such as users and recipes.\n" +
                                "Recipes: The Recipes section allows you to upload, edit, delete and view all available recipes. \n" +
                                "Employees: The Employees section is where you can manage information, fire, and promote \n" +
                                "employees to admins.\n" +
                                "Settings: The Settings section allows you to change your personal information.\n" +
                                "Log Out: The Log Out option allows you to exit the application.";
            }
            else if (roleName == "Employee")
            {
                lblGuide.Text = "Here is a little guide on how to use the application as an Employee:\n" +
                                "Dashboard: The Dashboard section provides an overview of statistics, related to the application, \n" +
                                "such as users and recipes.\n" +
                                "Recipes: The Recipes section allows you to upload, edit, delete and view all available recipes. \n" +
                                "Settings: The Settings section allows you to change your personal information.\n" +
                                "Log Out: The Log Out option allows you to exit the application.";
            }
        }

        private void LoadPieChart()
        {
            var users = userManager.GetAllDesktopUsers();
            int employeeCount = 0;
            int adminCount = 0;

            foreach (var user in users)
            {
                if (user.GetRole().GetName() == "Employee")
                {
                    employeeCount++;
                }
                else if (user.GetRole().GetName() == "Admin")
                {
                    adminCount++;
                }
            }

            pieChart.Series = new ISeries[]
            {
                new PieSeries<double> { Values = new double[] { employeeCount }, Name = "Employees" },
                new PieSeries<double> { Values = new double[] { adminCount }, Name = "Admins" }
            };

            pieChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;
        }
    }
}
