namespace recipe_desktop
{
    partial class MenuUC
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
            menu = new Label();
            SuspendLayout();
            // 
            // menu
            // 
            menu.Anchor = AnchorStyles.None;
            menu.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            menu.ForeColor = Color.White;
            menu.Image = Properties.Resources.analytics_xxl_2;
            menu.ImageAlign = ContentAlignment.TopCenter;
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Padding = new Padding(0, 15, 0, 15);
            menu.Size = new Size(195, 120);
            menu.TabIndex = 0;
            menu.Text = "label";
            menu.TextAlign = ContentAlignment.BottomCenter;
            // 
            // MenuUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(menu);
            Name = "MenuUC";
            Size = new Size(198, 120);
            Paint += MenuUC_Paint;
            ResumeLayout(false);
        }

        #endregion

        private Label menu;
    }
}
