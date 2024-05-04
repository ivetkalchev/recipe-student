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
            panel1 = new Panel();
            sideBarPanel1 = new SideBarPanel();
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
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(127, 149, 209);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(1902, 77);
            panel1.TabIndex = 2;
            // 
            // sideBarPanel1
            // 
            sideBarPanel1.Dock = DockStyle.Left;
            sideBarPanel1.gradientBottom = Color.FromArgb(46, 79, 166);
            sideBarPanel1.gradientTop = Color.FromArgb(127, 149, 209);
            sideBarPanel1.Location = new Point(0, 133);
            sideBarPanel1.Name = "sideBarPanel1";
            sideBarPanel1.Size = new Size(198, 900);
            sideBarPanel1.TabIndex = 3;
            // 
            // HomePageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1902, 1033);
            Controls.Add(sideBarPanel1);
            Controls.Add(panel1);
            Controls.Add(panelBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HomePageForm";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += HomePageForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBar;
        private Panel panel1;
        private SideBarPanel sideBarPanel1;
    }
}
