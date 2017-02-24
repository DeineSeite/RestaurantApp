using System.Net.Http;
using FreshMvvm;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using Xamarin.Forms;

namespace RestaurantApp.Core.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
            
        #region ctor
        public AccountViewModel()
        {
            SignUpCommand = new Command(SignUp);
            LoginCommand = new Command(Login);
            LogoutCommand = new Command(Logout);
        }
        #endregion

        #region  Public properties

        public string Email { get; set; }
        public string Password { get; set; }

        #endregion

        #region  Commands

        public Command SignUpCommand { get; set; }
        public Command LoginCommand { get; set; }
        public Command LogoutCommand { get; set; }

        #endregion

        #region  Public/Private members

        private void SignUp()
        {
            NavigationContentService.PushViewModel<SignUpViewModel>();
        }

        private async void Login()
        {
            try
            {
                var autService = FreshIOC.Container.Resolve<IAuthenticationService>();
                await autService.LoginAsync(Email, Password);
            }
            catch (HttpRequestException e)
            {
                AppDebugger.WriteLine("Login "+e.Message);
                DisplayService.DisplayAlert("Login failed:",e.Message);
            }
        }

        private void Logout()
        {
            var autService = FreshIOC.Container.Resolve<IAuthenticationService>();
            autService.LogoutAsync();
            NavigationContentService.PushViewModel<AccountViewModel>();
            NavigationContentService.CleanStackNavigation();
        }

        #endregion

    }
}