﻿using System;
using FreshMvvm;
using PropertyChanged;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using RestaurantApp.Core.ViewModels;
using Xamarin.Forms;


namespace RestaurantApp.Core.PageModels
{
    [ImplementPropertyChanged]
    public class MainPageModel : BasePageModel,IMainPageModel
    {
        public IBaseContentView MainContentView
        {
            get;
            set;
        }

        #region ctor
        public MainPageModel()
        {
            GoToAccountCommand = new Command(GoToAccountPage);
        }

        #endregion

        public Command GoToAccountCommand { get; set; }

        private void GoToAccountPage()
        {
            var contentNavigation = FreshIOC.Container.Resolve<IContentNavigationService>();
            contentNavigation.PushViewModel<AccountViewModel>();
        }
        

      
    }
}