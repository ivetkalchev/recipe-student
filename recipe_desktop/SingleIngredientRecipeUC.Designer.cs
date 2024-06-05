namespace recipe_desktop
{
    partial class SingleIngredientRecipeUC
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
            lblName = new Label();
            cbUnit = new ComboBox();
            tbServings = new TextBox();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(34, 33);
            lblName.Name = "lblName";
            lblName.Size = new Size(90, 30);
            lblName.TabIndex = 5;
            lblName.Text = "{Name}";
            // 
            // cbUnit
            // 
            cbUnit.Font = new Font("Segoe UI", 13F);
            cbUnit.ForeColor = Color.Black;
            cbUnit.FormattingEnabled = true;
            cbUnit.Location = new Point(336, 30);
            cbUnit.Name = "cbUnit";
            cbUnit.Size = new Size(97, 38);
            cbUnit.TabIndex = 61;
            // 
            // tbServings
            // 
            tbServings.Font = new Font("Segoe UI", 13F);
            tbServings.ForeColor = Color.Black;
            tbServings.Location = new Point(252, 30);
            tbServings.MaxLength = 100;
            tbServings.Name = "tbServings";
            tbServings.Size = new Size(78, 36);
            tbServings.TabIndex = 70;
            // 
            // SingleIngredientRecipeUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            Controls.Add(tbServings);
            Controls.Add(cbUnit);
            Controls.Add(lblName);
            Name = "SingleIngredientRecipeUC";
            Size = new Size(622, 94);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private ComboBox cbUnit;
        private TextBox tbServings;
    }
}
