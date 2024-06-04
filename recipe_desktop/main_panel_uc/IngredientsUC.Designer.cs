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
            cbTypeIngredient = new ComboBox();
            lblType = new Label();
            lblEuro = new Label();
            nudPrice = new NumericUpDown();
            btnUpload = new Button();
            tbName = new TextBox();
            lblUsername = new Label();
            lblFirstName = new Label();
            panelIngredients = new Panel();
            btnPrevious = new Button();
            btnNext = new Button();
            tbSearch = new TextBox();
            picSearch = new PictureBox();
            panel2 = new Panel();
            label1 = new Label();
            lblPfp = new Label();
            lblPrice = new Label();
            lblName = new Label();
            lblId = new Label();
            lblNoResults = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblAddIngredient
            // 
            lblAddIngredient.AutoSize = true;
            lblAddIngredient.BackColor = Color.Transparent;
            lblAddIngredient.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lblAddIngredient.ForeColor = Color.White;
            lblAddIngredient.Location = new Point(59, 28);
            lblAddIngredient.Name = "lblAddIngredient";
            lblAddIngredient.Size = new Size(343, 50);
            lblAddIngredient.TabIndex = 8;
            lblAddIngredient.Text = "Add An Ingredient:";
            lblAddIngredient.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(61, 83, 143);
            panel1.Controls.Add(cbTypeIngredient);
            panel1.Controls.Add(lblType);
            panel1.Controls.Add(lblAddIngredient);
            panel1.Controls.Add(lblEuro);
            panel1.Controls.Add(nudPrice);
            panel1.Controls.Add(btnUpload);
            panel1.Controls.Add(tbName);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(lblFirstName);
            panel1.Location = new Point(29, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(1628, 215);
            panel1.TabIndex = 9;
            // 
            // cbTypeIngredient
            // 
            cbTypeIngredient.Font = new Font("Segoe UI", 18F);
            cbTypeIngredient.ForeColor = Color.FromArgb(46, 79, 166);
            cbTypeIngredient.FormattingEnabled = true;
            cbTypeIngredient.Location = new Point(541, 127);
            cbTypeIngredient.Name = "cbTypeIngredient";
            cbTypeIngredient.Size = new Size(278, 49);
            cbTypeIngredient.TabIndex = 28;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblType.ForeColor = Color.White;
            lblType.Location = new Point(532, 87);
            lblType.Name = "lblType";
            lblType.Size = new Size(77, 38);
            lblType.TabIndex = 27;
            lblType.Text = "Type";
            // 
            // lblEuro
            // 
            lblEuro.AutoSize = true;
            lblEuro.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblEuro.ForeColor = Color.White;
            lblEuro.Location = new Point(874, 122);
            lblEuro.Name = "lblEuro";
            lblEuro.Size = new Size(44, 52);
            lblEuro.TabIndex = 26;
            lblEuro.Text = "€";
            // 
            // nudPrice
            // 
            nudPrice.DecimalPlaces = 2;
            nudPrice.Font = new Font("Segoe UI", 19F);
            nudPrice.ForeColor = Color.FromArgb(46, 79, 166);
            nudPrice.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            nudPrice.Location = new Point(924, 124);
            nudPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(192, 50);
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
            btnUpload.Location = new Point(1244, 128);
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
            tbName.Location = new Point(65, 131);
            tbName.Name = "tbName";
            tbName.Size = new Size(411, 47);
            tbName.TabIndex = 14;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(918, 87);
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
            lblFirstName.Location = new Point(57, 87);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(93, 38);
            lblFirstName.TabIndex = 11;
            lblFirstName.Text = "Name";
            // 
            // panelIngredients
            // 
            panelIngredients.Location = new Point(7, 382);
            panelIngredients.Margin = new Padding(5);
            panelIngredients.Name = "panelIngredients";
            panelIngredients.Padding = new Padding(4);
            panelIngredients.Size = new Size(1650, 437);
            panelIngredients.TabIndex = 10;
            // 
            // btnPrevious
            // 
            btnPrevious.BackColor = Color.White;
            btnPrevious.Cursor = Cursors.Hand;
            btnPrevious.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnPrevious.FlatAppearance.BorderSize = 2;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnPrevious.ForeColor = Color.FromArgb(46, 76, 157);
            btnPrevious.Location = new Point(670, 827);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(161, 49);
            btnPrevious.TabIndex = 12;
            btnPrevious.Text = "PREVIOUS";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(61, 83, 143);
            btnNext.Cursor = Cursors.Hand;
            btnNext.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnNext.FlatAppearance.BorderSize = 2;
            btnNext.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 76, 157);
            btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 76, 157);
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(853, 827);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(161, 49);
            btnNext.TabIndex = 11;
            btnNext.Text = "NEXT";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // tbSearch
            // 
            tbSearch.Font = new Font("Segoe UI", 18F);
            tbSearch.ForeColor = Color.FromArgb(46, 79, 166);
            tbSearch.Location = new Point(1273, 268);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(326, 47);
            tbSearch.TabIndex = 16;
            // 
            // picSearch
            // 
            picSearch.Image = Properties.Resources.search;
            picSearch.Location = new Point(1605, 266);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(50, 49);
            picSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            picSearch.TabIndex = 15;
            picSearch.TabStop = false;
            picSearch.Click += picSearch_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(46, 79, 166);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(lblPfp);
            panel2.Controls.Add(lblPrice);
            panel2.Controls.Add(lblName);
            panel2.Controls.Add(lblId);
            panel2.Location = new Point(22, 323);
            panel2.Name = "panel2";
            panel2.Size = new Size(1635, 51);
            panel2.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(607, 6);
            label1.Name = "label1";
            label1.Size = new Size(79, 38);
            label1.TabIndex = 17;
            label1.Text = "Type";
            // 
            // lblPfp
            // 
            lblPfp.AutoSize = true;
            lblPfp.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPfp.ForeColor = Color.White;
            lblPfp.Location = new Point(72, 6);
            lblPfp.Name = "lblPfp";
            lblPfp.Size = new Size(66, 38);
            lblPfp.TabIndex = 16;
            lblPfp.Text = "PFP";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.White;
            lblPrice.Location = new Point(856, 6);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(81, 38);
            lblPrice.TabIndex = 14;
            lblPrice.Text = "Price";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(365, 6);
            lblName.Name = "lblName";
            lblName.Size = new Size(95, 38);
            lblName.TabIndex = 11;
            lblName.Text = "Name";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblId.ForeColor = Color.White;
            lblId.Location = new Point(207, 6);
            lblId.Name = "lblId";
            lblId.Size = new Size(47, 38);
            lblId.TabIndex = 10;
            lblId.Text = "ID";
            // 
            // lblNoResults
            // 
            lblNoResults.AutoSize = true;
            lblNoResults.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoResults.ForeColor = Color.Firebrick;
            lblNoResults.Location = new Point(1008, 274);
            lblNoResults.Name = "lblNoResults";
            lblNoResults.Size = new Size(259, 41);
            lblNoResults.TabIndex = 18;
            lblNoResults.Text = "No Results Found";
            // 
            // IngredientsUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblNoResults);
            Controls.Add(panel2);
            Controls.Add(tbSearch);
            Controls.Add(picSearch);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(panelIngredients);
            Controls.Add(panel1);
            Name = "IngredientsUC";
            Size = new Size(1677, 891);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblAddIngredient;
        private Panel panel1;
        private Label lblUsername;
        private Label lblFirstName;
        private TextBox tbName;
        private Button btnUpload;
        private NumericUpDown nudPrice;
        private Label lblEuro;
        private Panel panelIngredients;
        private Button btnPrevious;
        private Button btnNext;
        private TextBox tbSearch;
        private PictureBox picSearch;
        private Panel panel2;
        private Label lblPfp;
        private Label lblPrice;
        private Label label2;
        private Label lblName;
        private Label lblId;
        private Label lblNoResults;
        private ComboBox cbTypeIngredient;
        private Label lblType;
        private Label label1;
    }
}
