using System;

namespace RestaurantApp.ContentViews
{
    public partial class AccountView : BaseContentView
    {
        public AccountView()
        {
            InitializeComponent();
        }

        private void SignUpButton_OnClicked(object sender, EventArgs e)
        {
            LoginView.IsVisible = false;
        }

        private void LoginButton_OnClicked(object sender, EventArgs e)
        {
            LoginView.IsVisible = false;
            AfterLoginView.IsVisible = true;
        }
    }
}