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
            btnAddRecipes.Location = new Point(633, 818);
            btnAddRecipes.Name = "btnAddRecipes";
            btnAddRecipes.Size = new Size(474, 49);
            btnAddRecipes.TabIndex = 6;
            btnAddRecipes.Text = "ADD RECIPES";
            btnAddRecipes.UseVisualStyleBackColor = false;
            btnAddRecipes.Click += btnAddRecipes_Click;
            // 
            // RecipesUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAddRecipes);
            Name = "RecipesUC";
            Size = new Size(1677, 870);
            ResumeLayout(false);
        }

        #endregion

        private Button btnAddRecipes;
    }
}
