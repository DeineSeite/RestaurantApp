using System;
using FreshMvvm;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
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
            var autService = FreshIOC.Container.Resolve<IAuthenticationService>();
            User=await autService.SignUp(User);
            Settings.UserId = User.Id;
        }

        #endregion

        #region ctor

        public SignUpViewModel()
        {
            User = new UserModel { BirthDay = DateTime.Now, Gender = GenderType.Man};
            SignUpCommand = new Command(SignUp);
        }

        #endregion
    }
}