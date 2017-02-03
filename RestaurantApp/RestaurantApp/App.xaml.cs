using System.Globalization;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.PageModels;
using RestaurantApp.Services;
using  RestaurantApp.Core.Resources;
using Xamarin.Forms;

namespace RestaurantApp
{
    public partial class App : Application, IApplicationContext
    {
        public App()
        {
            InitializeComponent();
            ChangeCurrentCultureInfo(CurrentCulture.Name);
            InitializeFreshMvvm();
         
            MainPage = BasicNavContainer;
        }

        public FreshNavigationContainer BasicNavContainer { get; set; }
        public CultureInfo CurrentCulture { get; set; } = new CultureInfo("de-De");

        public void ChangeCurrentCultureInfo(string langCode)
        {
            DependencyService.Get<ILocalize>().SetLocale(langCode);
            AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        private void InitializeFreshMvvm()
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