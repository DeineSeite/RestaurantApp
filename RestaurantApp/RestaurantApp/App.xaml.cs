using System.Collections.Generic;
using System.Globalization;
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
using RestaurantApp.Localizations;
using RestaurantApp.Pages;
using RestaurantApp.Services;
using Xamarin.Forms;

namespace RestaurantApp
{
    public partial class App : Application, IApplicationContext
    {
        #region  ctor

        public App()
        {
            InitializeComponent();
            ChangeCurrentCultureInfo(CurrentCulture.Name);
            InitializeFreshMvvm();
            InitializeSettings();
            InitializeStartMenu();
            MainPage = BasicNavContainer;
        }

        #endregion

        #region Constants  

        public const string AuthenticationEndpoint = "http://www.luckywok.at/";
        public static string TAG = "RestaurantApp";

        #endregion

        #region Public properties

        public Application Instance => Current;
        public FreshNavigationContainer BasicNavContainer { get; set; }
        public CultureInfo CurrentCulture { get; set; } = new CultureInfo("de-De");
        public MenuViewModel StartMenu { get; set; }

        #endregion

        #region Public/Private members

        public void ChangeCurrentCultureInfo(string langCode)
        {
            DependencyService.Get<ILocalize>().SetLocale(langCode);
            AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        private void InitializeFreshMvvm()
        {
            AppDebugger.WriteLine("Start InitializeFreshMvvm()");

            //Register interfaces
            FreshIOC.Container.Register<IApplicationContext>(this);
            FreshIOC.Container.Register<IContentNavigationService, ContentNavigationService>();
            FreshIOC.Container.Register<IRequestProvider, RequestProvider>();
            FreshIOC.Container.Register<IAuthenticationService, AuthenticationService>();

            //Register mappers for current project: YouTrack WIKI-5
            FreshPageModelResolver.PageModelMapper = new RestaurantAppModelMapper();
            ContentViewModelResolver.ViewModelMapper = new RestaurantAppModelMapper();

            AppDebugger.WriteLine("End InitializeFreshMvvm()");
        }

        private void InitializeSettings()
        {
            Settings.AuthenticationEndpoint = AuthenticationEndpoint;
            if (Settings.FirstStart)
            {
                
            }

        }
        private void InitializeStartMenu()
        {
            AppDebugger.WriteLine("InitializeStartMenu()");

            //Register MainPageModel as model with dynamic ContentView
            var mainPageModel = new MainPageModel();
            FreshIOC.Container.Register<IDynamicContent>(mainPageModel);

            //Resolve Page and start
            var mainContentPage = new MainPage {BindingContext = mainPageModel};
            BasicNavContainer = new FreshNavigationContainer(mainContentPage);

            AppDebugger.WriteLine("MainPage started");

            //Register ContentNavigationService
            var navService = new ContentNavigationService();
            FreshIOC.Container.Register<IContentNavigationService>(navService);

            AppDebugger.WriteLine("Registered ContentNavigationService");

            //Initialize menu items
            StartMenu = new MenuViewModel();
            var infoMenu = new MenuViewModel
            {
                MenuItemsList = new List<IBaseContentView>
                {
                    new OpenHoursView(),
                    new TableOrderView(),
                    new GalleryView()
                }
            };

            AppDebugger.WriteLine("Initialized menu items");

            var infoMenuView = new MenuView
            {
                BindingContext = infoMenu,
                Title = AppResources.Info
            };
            StartMenu.MenuItemsList = new List<IBaseContentView>
            {
                new BonusPointView(),
                infoMenuView,
                new FoodCardView(),
                new ContactView()
            };
            AppDebugger.WriteLine("Initialized infoMenuView");

            //Push menu as content
            var startMenuView = new MenuView {BindingContext = StartMenu};
            navService.PushContentView(startMenuView);
            AppDebugger.WriteLine("Push menu as content");
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