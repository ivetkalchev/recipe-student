namespace recipe_desktop
{
    partial class ForgottenPassword
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgottenPassword));
            panFP = new Panel();
            lblRegister = new Label();
            lblLogin = new Label();
            btnReveal = new Button();
            tbBSN = new TextBox();
            lblBSN = new Label();
            lblFPHeading = new Label();
            panFP.SuspendLayout();
            SuspendLayout();
            // 
            // panFP
            // 
            panFP.BackColor = Color.FromArgb(217, 217, 217);
            panFP.Controls.Add(lblRegister);
            panFP.Controls.Add(lblLogin);
            panFP.Controls.Add(btnReveal);
            panFP.Controls.Add(tbBSN);
            panFP.Controls.Add(lblBSN);
            panFP.Controls.Add(lblFPHeading);
            panFP.Location = new Point(289, 168);
            panFP.Name = "panFP";
            panFP.Size = new Size(461, 367);
            panFP.TabIndex = 1;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRegister.ForeColor = Color.FromArgb(255, 41, 107);
            lblRegister.Location = new Point(178, 295);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(84, 25);
            lblRegister.TabIndex = 8;
            lblRegister.Text = "Register";
            lblRegister.Click += lblRegister_Click;
            lblRegister.MouseLeave += lblRegister_MouseLeave;
            lblRegister.MouseHover += lblRegister_MouseHover;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogin.ForeColor = Color.FromArgb(255, 130, 169);
            lblLogin.Location = new Point(188, 270);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(63, 25);
            lblLogin.TabIndex = 7;
            lblLogin.Text = "Login";
            lblLogin.Click += lblLogin_Click;
            lblLogin.MouseLeave += lblLogin_MouseLeave;
            lblLogin.MouseHover += lblLogin_MouseHover;
            // 
            // btnReveal
            // 
            btnReveal.BackColor = Color.FromArgb(255, 130, 169);
            btnReveal.FlatAppearance.BorderColor = Color.FromArgb(255, 41, 107);
            btnReveal.FlatAppearance.BorderSize = 2;
            btnReveal.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 41, 107);
            btnReveal.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 41, 107);
            btnReveal.FlatStyle = FlatStyle.Flat;
            btnReveal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReveal.ForeColor = Color.White;
            btnReveal.Location = new Point(43, 220);
            btnReveal.Name = "btnReveal";
            btnReveal.Size = new Size(360, 38);
            btnReveal.TabIndex = 6;
            btnReveal.Text = "Reveal password";
            btnReveal.UseVisualStyleBackColor = false;
            btnReveal.Click += btnReveal_Click;
            // 
            // tbBSN
            // 
            tbBSN.Font = new Font("Segoe UI", 12F);
            tbBSN.Location = new Point(43, 167);
            tbBSN.MaxLength = 9;
            tbBSN.Name = "tbBSN";
            tbBSN.Size = new Size(360, 34);
            tbBSN.TabIndex = 2;
            tbBSN.KeyPress += tbBSN_KeyPress;
            // 
            // lblBSN
            // 
            lblBSN.AutoSize = true;
            lblBSN.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblBSN.ForeColor = Color.FromArgb(255, 130, 169);
            lblBSN.Location = new Point(43, 134);
            lblBSN.Name = "lblBSN";
            lblBSN.Size = new Size(56, 30);
            lblBSN.TabIndex = 1;
            lblBSN.Text = "BSN";
            // 
            // lblFPHeading
            // 
            lblFPHeading.AutoSize = true;
            lblFPHeading.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblFPHeading.ForeColor = Color.FromArgb(255, 41, 107);
            lblFPHeading.Location = new Point(42, 57);
            lblFPHeading.Name = "lblFPHeading";
            lblFPHeading.Size = new Size(371, 50);
            lblFPHeading.TabIndex = 0;
            lblFPHeading.Text = "Forgotten password";
            // 
            // ForgottenPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(127, 149, 209);
            ClientSize = new Size(1006, 721);
            Controls.Add(panFP);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ForgottenPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Forgotten Password";
            panFP.ResumeLayout(false);
            panFP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panFP;
        private Label lblRegister;
        private Label lblLogin;
        private Button btnReveal;
        private TextBox tbBSN;
        private Label lblBSN;
        private Label lblFPHeading;
    }
}