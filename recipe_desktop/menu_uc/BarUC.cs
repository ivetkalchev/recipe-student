namespace recipe_desktop
{
    public partial class BarUC : UserControl
    {
        public BarUC()
        {
            InitializeComponent();
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lblClose_MouseHover(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.FromArgb(210, 210, 210);
        }
        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.FromArgb(255, 255, 255);
        }
    }
}
