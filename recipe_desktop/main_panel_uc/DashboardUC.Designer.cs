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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoardUC));
            lblWelcomeUser = new Label();
            lblGuide = new Label();
            pieChart = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
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
            lblGuide.Font = new Font("Segoe UI", 20F);
            lblGuide.ForeColor = Color.FromArgb(46, 79, 166);
            lblGuide.Location = new Point(54, 101);
            lblGuide.Name = "lblGuide";
            lblGuide.Size = new Size(1452, 414);
            lblGuide.TabIndex = 3;
            lblGuide.Text = resources.GetString("lblGuide.Text");
            lblGuide.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pieChart
            // 
            pieChart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            pieChart.InitialRotation = 0D;
            pieChart.IsClockwise = true;
            pieChart.Location = new Point(54, 500);
            pieChart.MaxAngle = 360D;
            pieChart.MaxValue = null;
            pieChart.MinValue = 0D;
            pieChart.Name = "pieChart";
            pieChart.Size = new Size(508, 398);
            pieChart.TabIndex = 0;
            pieChart.Total = null;
            // 
            // DashBoardUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pieChart);
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
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart pieChart;
    }
}
