namespace recipe_desktop
{
    partial class RegisterUC : UserControl
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
            panel1 = new Panel();
            btnClear = new Button();
            lblText = new Label();
            lblRegister = new Label();
            btnSubmit = new Button();
            lblUsername = new Label();
            tbSecAnswer = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(125, 147, 208);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(lblText);
            panel1.Controls.Add(lblRegister);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(tbSecAnswer);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(8, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 709);
            panel1.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(61, 83, 143);
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnClear.FlatAppearance.BorderSize = 2;
            btnClear.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 76, 157);
            btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 76, 157);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(75, 410);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(474, 49);
            btnClear.TabIndex = 11;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblText.ForeColor = Color.White;
            lblText.Location = new Point(146, 526);
            lblText.Name = "lblText";
            lblText.Size = new Size(334, 35);
            lblText.TabIndex = 9;
            lblText.Text = "You don’t have an account?";
            lblText.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblRegister.ForeColor = Color.FromArgb(61, 83, 143);
            lblRegister.Location = new Point(254, 561);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(111, 35);
            lblRegister.TabIndex = 8;
            lblRegister.Text = "Register";
            lblRegister.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.White;
            btnSubmit.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnSubmit.FlatAppearance.BorderSize = 2;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.FromArgb(46, 76, 157);
            btnSubmit.Location = new Point(75, 465);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(474, 49);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "SUBMIT";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(66, 258);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(274, 40);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "{SecurityQuestion}";
            lblUsername.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbSecAnswer
            // 
            tbSecAnswer.Font = new Font("Segoe UI", 18F);
            tbSecAnswer.Location = new Point(75, 332);
            tbSecAnswer.Name = "tbSecAnswer";
            tbSecAnswer.Size = new Size(474, 47);
            tbSecAnswer.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(201, 12);
            label1.Name = "label1";
            label1.Size = new Size(221, 67);
            label1.TabIndex = 0;
            label1.Text = "Register";
            // 
            // RegisterUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(61, 83, 143);
            Controls.Add(panel1);
            Name = "RegisterUC";
            Size = new Size(654, 721);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox tbSecAnswer;
        private Label lblUsername;
        private Button btnSubmit;
        private Label lblText;
        private Label lblRegister;
        private Button btnClear;
    }
}
