﻿using System.Collections.Generic;
using System.Globalization;
using FreshMvvm;
using RestaurantApp.ContentViews;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.PageModels;
using RestaurantApp.Core.Services;
using RestaurantApp.Core.ViewModels;
using RestaurantApp.Localizations;
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
            InitializeStartMenu();
            MainPage = BasicNavContainer;
        }

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
            //Register containers
            FreshIOC.Container.Register<IApplicationContext>(this);
            FreshIOC.Container.Register<IContentNavigationService, ContentNavigationService>();

            //Register mappers for current project: YouTrack WIKI-5
            FreshPageModelResolver.PageModelMapper = new RestaurantAppModelMapper();
            ContentViewModelResolver.ViewModelMapper = new RestaurantAppModelMapper();
        }

        private void InitializeStartMenu()
        {
            //Register MainPageModel as model with dynamic ContentView
            var mainPageModel = new MainPageModel();
            FreshIOC.Container.Register<IDynamicContent>(mainPageModel);

            //Register ContentNavigationService
            var navService = new ContentNavigationService();
            FreshIOC.Container.Register<IContentNavigationService>(navService);

            //Initialize menu items
            StartMenu = new MenuViewModel();
            var infoMenu = new MenuViewModel();
            infoMenu.MenuItemsList = new List<IBaseContentView>
            {
                new OpenHoursView(),
                new TableOrderView(),
                new GalleryView()
            };

            var infoMenuView = (BaseContentView) ContentViewModelResolver.ResolveViewModel((object) null, infoMenu);
            infoMenuView.Title = AppResources.Info;
            StartMenu.MenuItemsList = new List<IBaseContentView>
            {
                new BonusPointView(),
                infoMenuView,
                new FoodCardView(),
                new ContactView()
            };


            //Resolve Page and start
            var mainContentPage = FreshPageModelResolver.ResolvePageModel((object) null, mainPageModel);
            BasicNavContainer = new FreshNavigationContainer(mainContentPage);


            //Set menu as content
            var startMenuView = (BaseContentView) ContentViewModelResolver.ResolveViewModel((object) null, StartMenu);
            navService.PushContentView(startMenuView);
        }

        #endregion

        #region  LifeCycle

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

        #endregion
    }
}