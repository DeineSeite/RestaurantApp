using Xamarin.Forms;

namespace RestaurantApp.UserControls
{
    public partial class TitleTemplate : ContentView
    {
        public TitleTemplate()
        {
            InitializeComponent();
        }

        public string TitleText
        {
            get { return TitleLabel.Text; }
            set { TitleLabel.Text = value; }
        }

        public string SubTitleText
        {
            get { return SubTitleLabel.Text; }
            set { SubTitleLabel.Text = value; }
        }
    }
}