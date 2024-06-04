using entity_classes;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using manager_classes;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Microsoft.VisualBasic.ApplicationServices;

namespace recipe_desktop
{
    public partial class DashBoardUC : UserControl
    {
        private DesktopUser user;
        private IUserManager userManager;
        private IIngredientManager ingredientManager;
        
        public DashBoardUC(DesktopUser user, IUserManager userManager, IIngredientManager ingredientManager)
        {
            InitializeComponent();

            this.user = user;
            this.userManager = userManager;
            this.ingredientManager = ingredientManager;


            SetGuideText(user.GetRole().GetName());
            LoadWelcomeText(user);
            LoadPieChartUsers();
        }
        
        private void LoadWelcomeText(DesktopUser user)
        {
            lblWelcomeUser.Text = $"Welcome, {user.GetFirstName()} {user.GetLastName()}!";
        }

        private void SetGuideText(string roleName)
        {
            if (roleName == "Admin")
            {
                lblGuide.Text = "Here is a little guide on how to use the application as an Admin:\n" +
                                "Dashboard: The Dashboard section provides an overview of statistics, related to the application, \n" +
                                "such as users and recipes.\n" +
                                "Recipes: The Recipes section allows you to upload, edit, delete and view all available recipes. \n" +
                                "Ingredients: The Ingredients section allows you to upload, edit, delete and view all ingredients. \n" +
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
                                "Ingredients: The Ingredients section allows you to upload, edit, delete and view all ingredients. \n" +
                                "Settings: The Settings section allows you to change your personal information.\n" +
                                "Log Out: The Log Out option allows you to exit the application.";
            }
        }

        private void LoadPieChartUsers()
        {
            var users = userManager.GetAllDesktopUsers();
            int employeeCount = 0;
            int adminCount = 0;

            foreach (var user in users)
            {
                var roleName = user.GetRole().GetName();
                if (roleName == "Employee")
                {
                    employeeCount++;
                }
                else if (roleName == "Admin")
                {
                    adminCount++;
                }
            }

            pieChartUsers.Series = new ISeries[]
            {
            new PieSeries<double>
            {
                Values = new double[] { employeeCount },
                Name = "Employees",
                Fill = new SolidColorPaint(new SKColor(98, 14, 80))
            },
            new PieSeries<double>
            {
                Values = new double[] { adminCount },
                Name = "Admins",
                Fill = new SolidColorPaint(new SKColor(182, 113, 169))
            }
                };

            pieChartUsers.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;
        }
    }
}
