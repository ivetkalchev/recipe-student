namespace recipe_desktop
{
    partial class IngredientsUC
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
            lblAddIngredient = new Label();
            panel1 = new Panel();
            lblEuro = new Label();
            cbUnits = new ComboBox();
            nudPrice = new NumericUpDown();
            btnUpload = new Button();
            tbName = new TextBox();
            lblUsername = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            SuspendLayout();
            // 
            // lblAddIngredient
            // 
            lblAddIngredient.AutoSize = true;
            lblAddIngredient.BackColor = Color.Transparent;
            lblAddIngredient.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lblAddIngredient.ForeColor = Color.White;
            lblAddIngredient.Location = new Point(126, 31);
            lblAddIngredient.Name = "lblAddIngredient";
            lblAddIngredient.Size = new Size(343, 50);
            lblAddIngredient.TabIndex = 8;
            lblAddIngredient.Text = "Add An Ingredient:";
            lblAddIngredient.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(61, 83, 143);
            panel1.Controls.Add(lblAddIngredient);
            panel1.Controls.Add(lblEuro);
            panel1.Controls.Add(cbUnits);
            panel1.Controls.Add(nudPrice);
            panel1.Controls.Add(btnUpload);
            panel1.Controls.Add(tbName);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(lblFirstName);
            panel1.Controls.Add(lblLastName);
            panel1.Location = new Point(29, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(1628, 221);
            panel1.TabIndex = 9;
            // 
            // lblEuro
            // 
            lblEuro.AutoSize = true;
            lblEuro.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblEuro.ForeColor = Color.White;
            lblEuro.Location = new Point(883, 124);
            lblEuro.Name = "lblEuro";
            lblEuro.Size = new Size(44, 52);
            lblEuro.TabIndex = 26;
            lblEuro.Text = "€";
            // 
            // cbUnits
            // 
            cbUnits.Font = new Font("Segoe UI", 18F);
            cbUnits.ForeColor = Color.FromArgb(46, 79, 166);
            cbUnits.FormattingEnabled = true;
            cbUnits.Location = new Point(641, 129);
            cbUnits.Name = "cbUnits";
            cbUnits.Size = new Size(83, 49);
            cbUnits.TabIndex = 25;
            // 
            // nudPrice
            // 
            nudPrice.DecimalPlaces = 2;
            nudPrice.Font = new Font("Segoe UI", 18F);
            nudPrice.ForeColor = Color.FromArgb(46, 79, 166);
            nudPrice.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            nudPrice.Location = new Point(933, 126);
            nudPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(192, 47);
            nudPrice.TabIndex = 16;
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.White;
            btnUpload.Cursor = Cursors.Hand;
            btnUpload.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnUpload.FlatAppearance.BorderSize = 2;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnUpload.ForeColor = Color.FromArgb(46, 76, 157);
            btnUpload.Location = new Point(1250, 124);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(255, 49);
            btnUpload.TabIndex = 15;
            btnUpload.Text = "UPLOAD";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 18F);
            tbName.ForeColor = Color.FromArgb(46, 79, 166);
            tbName.Location = new Point(136, 131);
            tbName.Name = "tbName";
            tbName.Size = new Size(411, 47);
            tbName.TabIndex = 14;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(926, 86);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(78, 38);
            lblUsername.TabIndex = 13;
            lblUsername.Text = "Price";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.White;
            lblFirstName.Location = new Point(126, 90);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(93, 38);
            lblFirstName.TabIndex = 11;
            lblFirstName.Text = "Name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            lblLastName.ForeColor = Color.White;
            lblLastName.Location = new Point(632, 87);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(70, 38);
            lblLastName.TabIndex = 12;
            lblLastName.Text = "Unit";
            // 
            // IngredientsUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "IngredientsUC";
            Size = new Size(1677, 870);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblAddIngredient;
        private Panel panel1;
        private Label lblUsername;
        private Label lblFirstName;
        private Label lblLastName;
        private TextBox tbName;
        private Button btnUpload;
        private NumericUpDown nudPrice;
        private Label lblEuro;
        private ComboBox cbUnits;
    }
}
