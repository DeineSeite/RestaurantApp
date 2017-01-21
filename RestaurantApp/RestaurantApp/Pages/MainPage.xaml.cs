using RestaurantApp.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantApp.Pages
{
    public partial class MainPage : BasePage
    {
        public MainPage()
        {
            InitializeComponent();
            HeaderPage.TitleControl.IsVisible = false;
        }

        protected override void OnAppearing()
        {
            //Menu.MenuListView.HeaderTemplate = null;
           
            base.OnAppearing();
        }
    }
}
