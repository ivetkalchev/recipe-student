namespace recipe_desktop
{
    partial class AuthenticationForm
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
            baruc1 = new BarUC();
            panelInput = new Panel();
            panelBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelBar
            // 
            panelBar.Controls.Add(baruc1);
            panelBar.Dock = DockStyle.Top;
            panelBar.Location = new Point(0, 0);
            panelBar.Name = "panelBar";
            panelBar.Size = new Size(1902, 56);
            panelBar.TabIndex = 0;
            // 
            // baruc1
            // 
            baruc1.BackColor = Color.FromArgb(61, 83, 143);
            baruc1.Dock = DockStyle.Top;
            baruc1.Location = new Point(0, 0);
            baruc1.Name = "baruc1";
            baruc1.Size = new Size(1902, 64);
            baruc1.TabIndex = 0;
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.FromArgb(125, 147, 208);
            panelInput.Location = new Point(639, 208);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(654, 721);
            panelInput.TabIndex = 1;
            // 
            // Authentication
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Login;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panelInput);
            Controls.Add(panelBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Authentication";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += AuthenticationForm_Load;
            panelBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBar;
        private Panel panelInput;
        private BarUC baruc1;
    }
}
