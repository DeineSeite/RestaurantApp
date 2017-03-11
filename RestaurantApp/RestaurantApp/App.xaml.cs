using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Com.OneSignal;
using FreshMvvm;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using RestaurantApp.ContentViews;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.PageModels;
using RestaurantApp.Core.Services;
using RestaurantApp.Core.ViewModels;
using RestaurantApp.Data.Access;
using RestaurantApp.Localizations;
using RestaurantApp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MenuItem = RestaurantApp.Data.Models.MenuItem;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace RestaurantApp
{
    public partial class App : Application, IApplicationContext
    {
        #region  ctor

        public App()
        {
            InitializeComponent();
            MobileCenter.LogLevel = LogLevel.Debug;
            Analytics.Enabled = true;
            ChangeCurrentCultureInfo(CurrentCulture.Name);
            InitializeFreshMvvm();
            RegisterInstances();
            InitializeSettings();
            InitializeStartMenu();
          
            //Set Start page
            MainPage = BasicNavContainer;

            Task.Run(() =>
            {
                InitializePushNotificationService();
            });
        }

        #endregion

        #region Constants  

        public const string AuthenticationEndpoint = "http://www.luckywok.at/";
        private const string TAG = "GASTRO";

        #endregion

        #region Public properties

        public FreshNavigationContainer BasicNavContainer { get; set; }
        public CultureInfo CurrentCulture { get; set; } = new CultureInfo("de-De");

        #endregion

        #region Public/Private members

        public void ChangeCurrentCultureInfo(string langCode)
        {
            DependencyService.Get<ILocalize>().SetLocale(langCode);
            AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        private void RegisterInstances()
        {
            FreshIOC.Container.Register<IApplicationContext>(this);
            FreshIOC.Container.Register<IContentNavigationService, ContentNavigationService>();
            FreshIOC.Container.Register<IRequestProvider, RequestProvider>();
            FreshIOC.Container.Register<IAuthenticationService, AuthenticationService>();
            FreshIOC.Container.Register<IRestaurantDataAccess, RestaurantDataAccess>();
            FreshIOC.Container.Register<IBonusPointService, BonusPointService>();
            FreshIOC.Container.Register<ITableOrderService, TableOrderService>();
            FreshIOC.Container.Register<IContentNavigationService, ContentNavigationService>().AsSingleton();
            FreshIOC.Container.Register<IMainPageModel,MainPageModel>().AsSingleton();
        }

        private void InitializeFreshMvvm()
        {
            //Register mappers for current project: YouTrack WIKI-5
            FreshPageModelResolver.PageModelMapper = new RestaurantAppModelMapper();
            ContentViewModelResolver.ViewModelMapper = new RestaurantAppModelMapper();
        }

        private void InitializeSettings()
        {
            Settings.AuthenticationEndpoint = AuthenticationEndpoint;
            if (Settings.FirstStart)
            {
                var dataBase = FreshIOC.Container.Resolve<IRestaurantDataAccess>();
                dataBase.CreateTables();
                Settings.FirstStart = false;
            }
        }

        private async void InitializeStartMenu()
        {
            //Register MainPageModel as model with dynamic ContentView
            var mainPageModel = FreshIOC.Container.Resolve<IMainPageModel>();

            //Resolve Page and start
            var mainContentPage = new MainPage();
            mainPageModel.CurrentPage = mainContentPage;
            mainContentPage.BindingContext = mainPageModel;

            BasicNavContainer = new FreshNavigationContainer(mainContentPage);

            await Task.Run(() =>
            {
                //Initialize menu items
               var menuItems = new List<MenuItem>
                {
                    new MenuItem(typeof(BonusPointMenuView), AppResources.BonusPoints),
                    new MenuItem(typeof(InfoMenuView), AppResources.Info),
                    new MenuItem(typeof(FoodCardView), AppResources.FoodCard),
                    new MenuItem(typeof(ContactView), AppResources.Contacts)
                };

                //Push menu as content
                var startMenuView = new MenuView();
                startMenuView.SetMenuItems(menuItems);
              
                var navService = FreshIOC.Container.Resolve<IContentNavigationService>();
                navService.PushContentView(startMenuView);
            });
        }

        private void InitializePushNotificationService()
        {
            try
            {
                OneSignal.Current.StartInit("fa5121e9-fe91-4836-89c6-e53e006346dd")
                    .EndInit();
            }
            catch (Exception e)
            {
                MobileCenterLog.Debug(TAG, "InitializePushNotificationService Failed: " + e.Message);
                throw;
            }
        }

        #endregion

        #region  LifeCycle

        protected override void OnStart()
        {
            MobileCenter.Start(typeof(Analytics), typeof(Crashes));
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

        #endregion
    }
}