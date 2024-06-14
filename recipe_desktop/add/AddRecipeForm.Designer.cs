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
            mainPanel = new Panel();
            MainCourse = new MenuUC();
            Drink = new MenuUC();
            Dessert = new MenuUC();
            lblHeaderText = new Label();
            sideBarPanel1 = new SideBarPanel();
            sideBarPanel1.SuspendLayout();
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
            btnClose.Location = new Point(1113, 6);
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
            label1.Location = new Point(473, -62);
            label1.Name = "label1";
            label1.Size = new Size(197, 40);
            label1.TabIndex = 40;
            label1.Text = "ADD RECIPES";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(182, 113, 169);
            mainPanel.Location = new Point(225, 54);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(930, 906);
            mainPanel.TabIndex = 0;
            // 
            // MainCourse
            // 
            MainCourse.BackColor = Color.Transparent;
            MainCourse.Cursor = Cursors.Hand;
            MainCourse.Icon = Properties.Resources.restaurant_512_1;
            MainCourse.Location = new Point(6, 56);
            MainCourse.MenuTitle = "Main Course";
            MainCourse.Name = "MainCourse";
            MainCourse.Size = new Size(224, 152);
            MainCourse.TabIndex = 43;
            // 
            // Drink
            // 
            Drink.BackColor = Color.Transparent;
            Drink.Cursor = Cursors.Hand;
            Drink.Icon = Properties.Resources.cocktail_512_1;
            Drink.Location = new Point(3, 365);
            Drink.MenuTitle = "Drink";
            Drink.Name = "Drink";
            Drink.Size = new Size(224, 152);
            Drink.TabIndex = 42;
            // 
            // Dessert
            // 
            Dessert.BackColor = Color.Transparent;
            Dessert.Cursor = Cursors.Hand;
            Dessert.Icon = Properties.Resources.banana_split_512_1;
            Dessert.Location = new Point(6, 207);
            Dessert.MenuTitle = "Dessert";
            Dessert.Name = "Dessert";
            Dessert.Size = new Size(224, 152);
            Dessert.TabIndex = 41;
            // 
            // lblHeaderText
            // 
            lblHeaderText.AutoSize = true;
            lblHeaderText.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeaderText.ForeColor = Color.White;
            lblHeaderText.Location = new Point(471, 6);
            lblHeaderText.Name = "lblHeaderText";
            lblHeaderText.Size = new Size(364, 38);
            lblHeaderText.TabIndex = 44;
            lblHeaderText.Text = "Add A Main Course Recipe";
            // 
            // sideBarPanel1
            // 
            sideBarPanel1.Controls.Add(MainCourse);
            sideBarPanel1.Controls.Add(Drink);
            sideBarPanel1.Controls.Add(Dessert);
            sideBarPanel1.gradientBottom = Color.FromArgb(65, 11, 54);
            sideBarPanel1.gradientTop = Color.FromArgb(98, 14, 80);
            sideBarPanel1.Location = new Point(-4, -2);
            sideBarPanel1.Name = "sideBarPanel1";
            sideBarPanel1.Size = new Size(1178, 970);
            sideBarPanel1.TabIndex = 0;
            // 
            // AddRecipeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(98, 14, 80);
            ClientSize = new Size(1162, 965);
            Controls.Add(lblHeaderText);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(mainPanel);
            Controls.Add(sideBarPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddRecipeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Recipes";
            sideBarPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnClose;
        private Label label1;
        private Panel mainPanel;
        private MenuUC MainCourse;
        private MenuUC Drink;
        private MenuUC Dessert;
        private Label lblHeaderText;
        private SideBarPanel sideBarPanel1;
    }
}