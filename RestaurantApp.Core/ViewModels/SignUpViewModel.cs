using System;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using RestaurantApp.Data.Models;
using Xamarin.Forms;

namespace RestaurantApp.Core.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        #region ctor
        public SignUpViewModel()
        {
            User = new UserModel { BirthDay = DateTime.Now,Gender = GenderType.Man};
            SignUpCommand = new Command(SignUp);
        }
        #endregion

        #region  Public properties

        public UserModel User { get; set; }

        #endregion

        #region Commands

        public Command SignUpCommand { get; set; }

        #endregion

        #region Public/Private members

        private void SignUp()
        {
            var autService = FreshIOC.Container.Resolve<IAuthenticationService>();
            autService.SignUp(User);
        }

        #endregion

    }
}