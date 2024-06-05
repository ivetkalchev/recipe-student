namespace recipe_desktop
{
    partial class DashBoardUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWelcomeUser = new Label();
            lblGuide = new Label();
            pieChartUsers = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            SuspendLayout();
            // 
            // lblWelcomeUser
            // 
            lblWelcomeUser.AutoSize = true;
            lblWelcomeUser.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblWelcomeUser.ForeColor = Color.FromArgb(46, 79, 166);
            lblWelcomeUser.Location = new Point(54, 34);
            lblWelcomeUser.Name = "lblWelcomeUser";
            lblWelcomeUser.Size = new Size(852, 67);
            lblWelcomeUser.TabIndex = 2;
            lblWelcomeUser.Text = "Welcome, {FirstName} {LastName}!\r\n";
            lblWelcomeUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGuide
            // 
            lblGuide.AutoSize = true;
            lblGuide.Font = new Font("Segoe UI", 17F);
            lblGuide.ForeColor = Color.FromArgb(46, 79, 166);
            lblGuide.Location = new Point(61, 111);
            lblGuide.Name = "lblGuide";
            lblGuide.Size = new Size(349, 40);
            lblGuide.TabIndex = 3;
            lblGuide.Text = "{guide for the application}";
            lblGuide.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pieChartUsers
            // 
            pieChartUsers.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            pieChartUsers.InitialRotation = 0D;
            pieChartUsers.IsClockwise = true;
            pieChartUsers.Location = new Point(54, 510);
            pieChartUsers.MaxAngle = 360D;
            pieChartUsers.MaxValue = null;
            pieChartUsers.MinValue = 0D;
            pieChartUsers.Name = "pieChartUsers";
            pieChartUsers.Size = new Size(537, 370);
            pieChartUsers.TabIndex = 0;
            pieChartUsers.Total = null;
            // 
            // DashBoardUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pieChartUsers);
            Controls.Add(lblGuide);
            Controls.Add(lblWelcomeUser);
            Name = "DashBoardUC";
            Size = new Size(1677, 883);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblWelcomeUser;
        private Label lblGuide;
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart pieChartUsers;
    }
}
