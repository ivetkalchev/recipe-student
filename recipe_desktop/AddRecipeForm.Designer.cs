namespace recipe_desktop
{
    partial class AddRecipeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRecipeForm));
            btnClose = new Button();
            label1 = new Label();
            panel1 = new Panel();
            AddMainCourse = new MenuUC();
            AddDrink = new MenuUC();
            AddDessert = new MenuUC();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnClose.FlatAppearance.BorderSize = 2;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(98, 14, 80);
            btnClose.Location = new Point(559, 8);
            btnClose.Margin = new Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(0, 0, 0, 2);
            btnClose.Size = new Size(42, 45);
            btnClose.TabIndex = 13;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(205, 9);
            label1.Name = "label1";
            label1.Size = new Size(197, 40);
            label1.TabIndex = 40;
            label1.Text = "ADD RECIPES";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(182, 113, 169);
            panel1.Controls.Add(AddMainCourse);
            panel1.Controls.Add(AddDrink);
            panel1.Controls.Add(AddDessert);
            panel1.Location = new Point(5, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(597, 165);
            panel1.TabIndex = 0;
            // 
            // AddMainCourse
            // 
            AddMainCourse.BackColor = Color.FromArgb(98, 14, 80);
            AddMainCourse.Cursor = Cursors.Hand;
            AddMainCourse.Icon = Properties.Resources.restaurant_512_1;
            AddMainCourse.Location = new Point(9, 8);
            AddMainCourse.MenuTitle = "Main Course";
            AddMainCourse.Name = "AddMainCourse";
            AddMainCourse.Size = new Size(190, 150);
            AddMainCourse.TabIndex = 2;
            // 
            // AddDrink
            // 
            AddDrink.BackColor = Color.FromArgb(98, 14, 80);
            AddDrink.Cursor = Cursors.Hand;
            AddDrink.Icon = Properties.Resources.cocktail_512_1;
            AddDrink.Location = new Point(401, 8);
            AddDrink.MenuTitle = "Drink";
            AddDrink.Name = "AddDrink";
            AddDrink.Size = new Size(190, 150);
            AddDrink.TabIndex = 1;
            // 
            // AddDessert
            // 
            AddDessert.BackColor = Color.FromArgb(98, 14, 80);
            AddDessert.Cursor = Cursors.Hand;
            AddDessert.Icon = Properties.Resources.banana_split_512_1;
            AddDessert.Location = new Point(205, 8);
            AddDessert.MenuTitle = "Dessert";
            AddDessert.Name = "AddDessert";
            AddDessert.Size = new Size(190, 150);
            AddDessert.TabIndex = 0;
            // 
            // AddRecipeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(98, 14, 80);
            ClientSize = new Size(610, 229);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddRecipeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Recipes";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnClose;
        private Label label1;
        private Panel panel1;
        private MenuUC AddMainCourse;
        private MenuUC AddDrink;
        private MenuUC AddDessert;
    }
}