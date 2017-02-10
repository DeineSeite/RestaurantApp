using FreshMvvm;
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
        }
        #endregion

        #region  Public properties

        public string Email { get; set; }
        public string Password { get; set; }

        #endregion

        #region  Commands

        public Command SignUpCommand { get; set; }
        public Command LoginCommand { get; set; }

        #endregion

        #region  Public/Private members

        private void SignUp()
        {
            var signUpView = ContentViewModelResolver.ResolveViewModel<SignUpViewModel>();
            NavigationContentService.PushContentView(signUpView);
        }

        private void Login()
        {
            var autService = FreshIOC.Container.Resolve<IAuthenticationService>();
            autService.LoginAsync(Email, Password);
        }

        #endregion

    }
}