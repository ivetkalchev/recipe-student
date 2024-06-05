using entity_classes;
using exceptions;
using LiveChartsCore.SkiaSharpView.Painting.ImageFilters;
using manager_classes;

namespace recipe_desktop
{
    public partial class AddDrinkForm : Form
    {
        public AddDrinkForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}