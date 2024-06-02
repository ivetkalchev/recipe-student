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
            btnAddRecipe = new Button();
            SuspendLayout();
            // 
            // btnAddRecipe
            // 
            btnAddRecipe.BackColor = Color.FromArgb(61, 83, 143);
            btnAddRecipe.Cursor = Cursors.Hand;
            btnAddRecipe.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnAddRecipe.FlatAppearance.BorderSize = 2;
            btnAddRecipe.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 76, 157);
            btnAddRecipe.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 76, 157);
            btnAddRecipe.FlatStyle = FlatStyle.Flat;
            btnAddRecipe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnAddRecipe.ForeColor = Color.White;
            btnAddRecipe.Location = new Point(988, 799);
            btnAddRecipe.Name = "btnAddRecipe";
            btnAddRecipe.Size = new Size(474, 49);
            btnAddRecipe.TabIndex = 7;
            btnAddRecipe.Text = "ADD A RECIPE";
            btnAddRecipe.UseVisualStyleBackColor = false;
            // 
            // RecipesUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAddRecipe);
            Name = "RecipesUC";
            Size = new Size(1677, 870);
            ResumeLayout(false);
        }

        #endregion
        private Button btnAddRecipe;
    }
}
