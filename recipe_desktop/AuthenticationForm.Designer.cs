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
            panelInput = new Panel();
            SuspendLayout();
            // 
            // panelBar
            // 
            panelBar.Location = new Point(0, 0);
            panelBar.Name = "panelBar";
            panelBar.Size = new Size(1920, 56);
            panelBar.TabIndex = 0;
            // 
            // panelInput
            // 
            panelInput.Location = new Point(639, 208);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(654, 721);
            panelInput.TabIndex = 1;
            // 
            // AuthenticationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Login;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panelInput);
            Controls.Add(panelBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AuthenticationForm";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += AuthenticationForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBar;
        private Panel panelInput;
    }
}
