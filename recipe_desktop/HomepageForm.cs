using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using manager_classes;
using entity_classes;
using db_helpers;

namespace recipe_desktop
{
    public partial class HomePageForm : Form
    {
        private const int VM_NCHITEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private bool m_aeroEnabled;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        private DesktopUser currentUser;
        private IUserManager userManager;

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        [System.Runtime.InteropServices.DllImport("Ddi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCPAINT && (int)m.Result == HTCLIENT)
                m.Result = (IntPtr)HTCAPTION;
        }

        List<MenuUC> menuButtons;

        public HomePageForm(IUserManager userManager, DesktopUser user)
        {
            InitializeComponent();
            menuButtons = new List<MenuUC>() { Dashboard, Recipes, Employees, Settings, Log_Out };
            ClickMenu(menuButtons);
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.currentUser = user ?? throw new ArgumentNullException(nameof(user));
        }

        private void ClickMenu(List<MenuUC> _menu)
        {
            foreach (var menu in _menu)
            {
                menu.MenuClick += Menu_menuClick;
            }
        }

        private void Menu_menuClick(object sender, EventArgs e)
        {
            MenuUC _menuButton = (MenuUC)sender;
            ClearPanel();

            switch (_menuButton.Name)
            {
                case "Dashboard":
                    lblHeaderText.Text = "Dashboard";
                    LoadDashboard();
                    break;

                case "Recipes":
                    lblHeaderText.Text = "Recipes";
                    LoadRecipes();
                    break;

                case "Employees":
                    lblHeaderText.Text = "Employees";
                    LoadEmployees();
                    break;

                case "Settings":
                    lblHeaderText.Text = "Settings";
                    LoadSettings();
                    break;

                case "Log_Out":
                    LogOut();
                    break;
            }
        }

        private void LogOut()
        {
            AuthenticationForm authForm = new AuthenticationForm();
            authForm.Show();
            this.Close();
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            LoadBar();
            LoadDashboard();
        }

        private void LoadBar()
        {
            BarUC barUC = new BarUC();
            barUC.Dock = DockStyle.Fill;
            panelBar.Controls.Add(barUC);
        }

        public void LoadSettings()
        {
            SettingsUC settingsUC = new SettingsUC(userManager, currentUser);
            settingsUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(settingsUC);
        }

        public void LoadDashboard()
        {
            DashBoardUC dashboardUC = new DashBoardUC(currentUser);
            dashboardUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(dashboardUC);
        }

        public void LoadRecipes()
        {
            RecipesUC recipesUC = new RecipesUC();
            recipesUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(recipesUC);
        }

        public void LoadEmployees()
        {
            EmployeesUC employeesUC = new EmployeesUC();
            employeesUC.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(employeesUC);
        }

        public void ClearPanel()
        {
            mainPanel.Controls.Clear();
        }
    }
}
