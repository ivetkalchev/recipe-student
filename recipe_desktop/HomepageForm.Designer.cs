namespace recipe_desktop
{
    partial class HomePageForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelBar = new Panel();
            pamelHeader = new Panel();
            lblHeaderText = new Label();
            sideBarPanel1 = new SideBarPanel();
            Log_Out = new MenuUC();
            Settings = new MenuUC();
            Employees = new MenuUC();
            Recipes = new MenuUC();
            Dashboard = new MenuUC();
            mainPanel = new Panel();
            pamelHeader.SuspendLayout();
            sideBarPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBar
            // 
            panelBar.Dock = DockStyle.Top;
            panelBar.Location = new Point(0, 0);
            panelBar.Name = "panelBar";
            panelBar.Size = new Size(1902, 56);
            panelBar.TabIndex = 0;
            // 
            // pamelHeader
            // 
            pamelHeader.BackColor = Color.FromArgb(127, 149, 209);
            pamelHeader.Controls.Add(lblHeaderText);
            pamelHeader.Dock = DockStyle.Top;
            pamelHeader.Location = new Point(0, 56);
            pamelHeader.Name = "pamelHeader";
            pamelHeader.Size = new Size(1902, 77);
            pamelHeader.TabIndex = 2;
            // 
            // lblHeaderText
            // 
            lblHeaderText.Dock = DockStyle.Fill;
            lblHeaderText.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeaderText.ForeColor = Color.White;
            lblHeaderText.Location = new Point(0, 0);
            lblHeaderText.Name = "lblHeaderText";
            lblHeaderText.Size = new Size(1902, 77);
            lblHeaderText.TabIndex = 0;
            lblHeaderText.Text = "Dashboard";
            lblHeaderText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sideBarPanel1
            // 
            sideBarPanel1.Controls.Add(Log_Out);
            sideBarPanel1.Controls.Add(Settings);
            sideBarPanel1.Controls.Add(Employees);
            sideBarPanel1.Controls.Add(Recipes);
            sideBarPanel1.Controls.Add(Dashboard);
            sideBarPanel1.Dock = DockStyle.Left;
            sideBarPanel1.gradientBottom = Color.FromArgb(46, 79, 166);
            sideBarPanel1.gradientTop = Color.FromArgb(127, 149, 209);
            sideBarPanel1.Location = new Point(0, 133);
            sideBarPanel1.Name = "sideBarPanel1";
            sideBarPanel1.Size = new Size(198, 900);
            sideBarPanel1.TabIndex = 3;
            // 
            // Log_Out
            // 
            Log_Out.BackColor = Color.Transparent;
            Log_Out.Cursor = Cursors.Hand;
            Log_Out.Icon = Properties.Resources.logout_xxl_2;
            Log_Out.Location = new Point(-3, 536);
            Log_Out.MenuTitle = "Log Out";
            Log_Out.Name = "Log_Out";
            Log_Out.Size = new Size(198, 123);
            Log_Out.TabIndex = 4;
            // 
            // Settings
            // 
            Settings.BackColor = Color.Transparent;
            Settings.Cursor = Cursors.Hand;
            Settings.Icon = Properties.Resources.settings_25_xxl_2;
            Settings.Location = new Point(0, 407);
            Settings.MenuTitle = "Settings";
            Settings.Name = "Settings";
            Settings.Size = new Size(198, 123);
            Settings.TabIndex = 3;
            // 
            // Employees
            // 
            Employees.BackColor = Color.Transparent;
            Employees.Cursor = Cursors.Hand;
            Employees.Icon = Properties.Resources.user_xxl_2;
            Employees.Location = new Point(0, 278);
            Employees.MenuTitle = "Employees";
            Employees.Name = "Employees";
            Employees.Size = new Size(198, 123);
            Employees.TabIndex = 2;
            // 
            // Recipes
            // 
            Recipes.BackColor = Color.Transparent;
            Recipes.Cursor = Cursors.Hand;
            Recipes.Icon = Properties.Resources.pizza_xxl_2;
            Recipes.Location = new Point(0, 149);
            Recipes.MenuTitle = "Recipes";
            Recipes.Name = "Recipes";
            Recipes.Size = new Size(198, 123);
            Recipes.TabIndex = 1;
            // 
            // Dashboard
            // 
            Dashboard.BackColor = Color.Transparent;
            Dashboard.Cursor = Cursors.Hand;
            Dashboard.Icon = Properties.Resources.analytics_xxl_2;
            Dashboard.Location = new Point(0, 20);
            Dashboard.MenuTitle = "Dashboard";
            Dashboard.Name = "Dashboard";
            Dashboard.Size = new Size(198, 123);
            Dashboard.TabIndex = 0;
            // 
            // mainPanel
            // 
            mainPanel.Location = new Point(213, 151);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1677, 882);
            mainPanel.TabIndex = 4;
            // 
            // HomePageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1902, 1033);
            Controls.Add(mainPanel);
            Controls.Add(sideBarPanel1);
            Controls.Add(pamelHeader);
            Controls.Add(panelBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HomePageForm";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += HomePageForm_Load;
            pamelHeader.ResumeLayout(false);
            sideBarPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBar;
        private Panel pamelHeader;
        private SideBarPanel sideBarPanel1;
        private MenuUC Dashboard;
        private MenuUC Settings;
        private MenuUC Employees;
        private MenuUC Recipes;
        private MenuUC Log_Out;
        private Label lblHeaderText;
        private Panel mainPanel;
    }
}
