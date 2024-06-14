using db_helpers;
using manager_classes;

namespace recipe_desktop
{
    public partial class AuthenticationForm : Form
    {
        private IUserManager userManager;

        public AuthenticationForm()
        {
            InitializeComponent();
            this.userManager = new UserManager(new DBUserHelper());
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {
            LoadLogin();
        }

        public void ClearPanel()
        {
            panelInput.Controls.Clear();
        }

        public void LoadLogin()
        {
            LoadUserControl(new LoginUC(userManager));
        }

        public void LoadRegister()
        {
            LoadUserControl(new RegisterUC(userManager));
        }

        private void LoadUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelInput.Controls.Add(userControl);
        }
    }
}
