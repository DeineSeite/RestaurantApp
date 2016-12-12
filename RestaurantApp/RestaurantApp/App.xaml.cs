using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreshMvvm;
using RestaurantApp.Core.PageModels;
using RestaurantApp.Services;
using Xamarin.Forms;

namespace RestaurantApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeFreshMvvm();
            MainPage = FreshPageModelResolver.ResolvePageModel<MainPageModel>();
        }
        void InitializeFreshMvvm()
        {
            FreshPageModelResolver.PageModelMapper = new RestaurantAppPageModelMapper();
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
