using System;

namespace RestaurantApp.ContentViews
{
    public partial class AccountView : BaseContentView
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

        private void LoginButton_OnClicked(object sender, EventArgs e)
        {
            LoginView.IsVisible = false;
            AfterLoginView.IsVisible = true;
        }
    }
}