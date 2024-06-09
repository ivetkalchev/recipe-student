namespace recipe_desktop
{
    partial class RecipesUC
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
            btnAddRecipes = new Button();
            lblNoResults = new Label();
            tbSearch = new TextBox();
            picSearch = new PictureBox();
            panel1 = new Panel();
            label1 = new Label();
            lblRole = new Label();
            lblFirstName = new Label();
            panelRecipes = new Panel();
            btnPrevious = new Button();
            btnNext = new Button();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddRecipes
            // 
            btnAddRecipes.BackColor = Color.FromArgb(61, 83, 143);
            btnAddRecipes.Cursor = Cursors.Hand;
            btnAddRecipes.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnAddRecipes.FlatAppearance.BorderSize = 2;
            btnAddRecipes.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 76, 157);
            btnAddRecipes.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 76, 157);
            btnAddRecipes.FlatStyle = FlatStyle.Flat;
            btnAddRecipes.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnAddRecipes.ForeColor = Color.White;
            btnAddRecipes.Location = new Point(29, 9);
            btnAddRecipes.Name = "btnAddRecipes";
            btnAddRecipes.Size = new Size(459, 46);
            btnAddRecipes.TabIndex = 6;
            btnAddRecipes.Text = "ADD RECIPES";
            btnAddRecipes.UseVisualStyleBackColor = false;
            btnAddRecipes.Click += btnAddRecipes_Click;
            // 
            // lblNoResults
            // 
            lblNoResults.AutoSize = true;
            lblNoResults.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoResults.ForeColor = Color.Firebrick;
            lblNoResults.Location = new Point(900, 14);
            lblNoResults.Name = "lblNoResults";
            lblNoResults.Size = new Size(259, 41);
            lblNoResults.TabIndex = 22;
            lblNoResults.Text = "No Results Found";
            // 
            // tbSearch
            // 
            tbSearch.Font = new Font("Segoe UI", 18F);
            tbSearch.ForeColor = Color.Black;
            tbSearch.Location = new Point(1186, 8);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(417, 47);
            tbSearch.TabIndex = 21;
            // 
            // picSearch
            // 
            picSearch.Image = Properties.Resources.search;
            picSearch.Location = new Point(1612, 6);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(50, 49);
            picSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            picSearch.TabIndex = 20;
            picSearch.TabStop = false;
            picSearch.Click += picSearch_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(61, 83, 143);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblRole);
            panel1.Controls.Add(lblFirstName);
            panel1.Location = new Point(29, 71);
            panel1.Name = "panel1";
            panel1.Size = new Size(1630, 51);
            panel1.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(33, 6);
            label1.Name = "label1";
            label1.Size = new Size(55, 38);
            label1.TabIndex = 15;
            label1.Text = "Pic";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.ForeColor = Color.White;
            lblRole.Location = new Point(965, 6);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(75, 38);
            lblRole.TabIndex = 14;
            lblRole.Text = "User";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFirstName.ForeColor = Color.White;
            lblFirstName.Location = new Point(121, 6);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(75, 38);
            lblFirstName.TabIndex = 11;
            lblFirstName.Text = "Title";
            // 
            // panelRecipes
            // 
            panelRecipes.Location = new Point(12, 130);
            panelRecipes.Margin = new Padding(5);
            panelRecipes.Name = "panelRecipes";
            panelRecipes.Padding = new Padding(4);
            panelRecipes.Size = new Size(1650, 685);
            panelRecipes.TabIndex = 18;
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
            btnPrevious.Location = new Point(667, 823);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(161, 49);
            btnPrevious.TabIndex = 24;
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
            btnNext.Location = new Point(849, 823);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(161, 49);
            btnNext.TabIndex = 23;
            btnNext.Text = "NEXT";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // RecipesUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(btnAddRecipes);
            Controls.Add(lblNoResults);
            Controls.Add(tbSearch);
            Controls.Add(picSearch);
            Controls.Add(panel1);
            Controls.Add(panelRecipes);
            Name = "RecipesUC";
            Size = new Size(1677, 905);
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddRecipes;
        private Label lblNoResults;
        private TextBox tbSearch;
        private PictureBox picSearch;
        private Panel panel1;
        private Label lblRole;
        private Label lblFirstName;
        private Panel panelRecipes;
        private Button btnPrevious;
        private Button btnNext;
        private Label label1;
    }
}
