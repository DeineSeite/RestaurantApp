using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.ViewModels;
using Xamarin.Forms;

namespace RestaurantApp.ContentViews
{
    public partial class AccountView: BaseContentView
    {
        public AccountView()
        {
            InitializeComponent();
            SignUpView.IsVisible = false;
        }

        private void SignUpButton_OnClicked(object sender, EventArgs e)
        {

            LoginView.IsVisible = false;
            SignUpView.IsVisible = true;
        }
    }
}
