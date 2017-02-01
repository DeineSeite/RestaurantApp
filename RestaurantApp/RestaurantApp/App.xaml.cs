using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.PageModels;
using RestaurantApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application, IApplicationContext
    {

        public FreshNavigationContainer BasicNavContainer { get; set; }

        public App()
        {
            InitializeComponent();
            InitializeFreshMvvm();
            MainPage = BasicNavContainer;
        }

        void InitializeFreshMvvm()
        {
            FreshIOC.Container.Register<IApplicationContext, App>();
            FreshPageModelResolver.PageModelMapper = new RestaurantAppPageModelMapper();
            var mainPage = FreshPageModelResolver.ResolvePageModel<MainPageModel>();
            BasicNavContainer = new FreshNavigationContainer(mainPage);
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