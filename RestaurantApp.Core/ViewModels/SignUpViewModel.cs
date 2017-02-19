using System;
using System.Net.Http;
using FreshMvvm;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using RestaurantApp.Data.Models;
using Xamarin.Forms;

namespace RestaurantApp.Core.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        private string _fullName;

        #region  Public properties


        public UserModel User { get; set; }

        #endregion

        #region Commands

        public Command SignUpCommand { get; set; }

        #endregion

        #region Public/Private members

        private async void SignUp()
        {
            try
            {
                var autService = FreshIOC.Container.Resolve<IAuthenticationService>();
                var newUser = await autService.SignUp(User);
                Settings.UserId = newUser.Id;
                Settings.UserName = newUser.FirstName + " " + newUser.LastName;
                NavigationContentService.PushViewModel<AccountViewModel>();
                NavigationContentService.CleanStackNavigation();
            }
            catch (HttpRequestException e)
            {
                DisplayService.DisplayAlert("Signup error ", e.Message);
            }
            catch (Exception e)
            {
                DisplayService.DisplayAlert("Fatal error ", e.Message);
            }

        }

        #endregion

        #region ctor

        public SignUpViewModel()
        {
            User = new UserModel { BirthDay = DateTime.Now, Gender = GenderType.Man };
            SignUpCommand = new Command(SignUp);
        }

        #endregion
    }
}