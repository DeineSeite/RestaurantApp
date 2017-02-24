using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
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
using RestaurantApp.Data.Models;
using RestaurantApp.Localizations;
using RestaurantApp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace RestaurantApp
{
    public partial class App : Application, IApplicationContext
    {
        #region  ctor

        public App()
        {
            InitializeComponent();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            ChangeCurrentCultureInfo(CurrentCulture.Name);

            InitializeFreshMvvm();
            AppDebugger.WriteLine("InitializeFreshMvvm time: " + watch.ElapsedMilliseconds);

            RegisterInstances();
            AppDebugger.WriteLine("RegisterInstances time: " + watch.ElapsedMilliseconds);

            InitializeSettings();
            AppDebugger.WriteLine("InitializeSettings time: " + watch.ElapsedMilliseconds);

            InitializeStartMenu();
            AppDebugger.WriteLine("InitializeStartMenu time: " + watch.ElapsedMilliseconds);

            MainPage = BasicNavContainer;

            watch.Stop();
            AppDebugger.WriteLine("Start time: " + watch.ElapsedMilliseconds);
        }


        #endregion

        #region Constants  

        public const string AuthenticationEndpoint = "http://www.luckywok.at/";
        public static string TAG = "RestaurantApp";

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
            var mainPageModel = new MainPageModel();
            FreshIOC.Container.Register<IDynamicContent>(mainPageModel);
            FreshIOC.Container.Register<IMainPageModel>(mainPageModel);


            //Resolve Page and start
            var mainContentPage = new MainPage();
            mainPageModel.CurrentPage = mainContentPage;
            mainContentPage.BindingContext = mainPageModel;

            BasicNavContainer = new FreshNavigationContainer(mainContentPage);
            await Task.Run(() => { 
            
            //Register ContentNavigationService
            var navService = new ContentNavigationService();
            FreshIOC.Container.Register<IContentNavigationService>(navService);

            //Initialize menu items
            var  startMenu = new MenuViewModel();
            var infoMenu = new MenuViewModel
            {
                MenuItemsList = new List<IBaseContentView>
                {
                    new OpenHoursView(),
                    new TableOrderView(),
                    new GalleryView()
                }
            };

            var bonusPointsMenu = new MenuViewModel()
            {
                MenuItemsList = new List<IBaseContentView>()
                {
                    new BonusPointView(BonusPointType.Dinner) {Title = AppResources.Dinner},
                    new BonusPointView(BonusPointType.Lunch) {Title = AppResources.Lunch}
                }
            };
            var bonusPointsView = new MenuView
            {
                BindingContext = bonusPointsMenu,
                Title = AppResources.BonusPoints
            };

            var infoMenuView = new MenuView
            {
                BindingContext = infoMenu,
                Title = AppResources.Info
            };
            
            startMenu.MenuItemsList = new List<IBaseContentView>
            {
               bonusPointsView,
                infoMenuView,
                new FoodCardView(),
                new ContactView()
            };
            
            //Push menu as content
            var startMenuView = new MenuView {BindingContext = startMenu};
            navService.PushContentView(startMenuView);
            });
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