using System;
using System.Collections.Generic;
using FreshMvvm;
using RestaurantApp.ContentViews;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using RestaurantApp.Core.ViewModels;
using Xamanimation;
using Xamarin.Forms;

namespace RestaurantApp.Pages
{
    public partial class MainPage : BasePage
    {
        public static readonly BindableProperty MainContentProperty =
            BindableProperty.Create<MainPage, View>(p => p.Content, null,
                BindingMode.TwoWay, null,
                ContentChanged, null, null);

        public MainPage()
        {
            InitializeComponent();
            StackNavigation = new List<BaseContentView>();
            this.SetBinding(MainContentProperty, "MainContentView");
        }

        public BaseContentView MainContent
        {
            get { return (BaseContentView) GetValue(MainContentProperty); }
            set { SetValue(MainContentProperty, value); }
        }

        //TODO: StackNavigation is not working properly
        private List<BaseContentView> StackNavigation { get; }


        private static async void ContentChanged(BindableObject obj, View oldValue, View newValue)
        {
            try
            {
                var currentPage = obj as MainPage;

                if (currentPage != null)
                {
                    var titleControl = currentPage.HeaderPage.TitleControl;
                    //Hide Title if MenuView
                    if (newValue.GetType() != typeof(MenuView))
                    {
                        titleControl.IsVisible = true;
                      //  await titleControl.Animate(new TranslateToAnimation { TranslateY = 0, Duration = "300" });
                        //Set Title and Subtitle text for current view
                        titleControl.TitleText = ((BaseContentView) newValue).Title;
                        titleControl.SubTitleText = ((BaseContentView) newValue).SubTitle;

                       
                    }
                    else
                    {
                        //await titleControl.Animate(new TranslateToAnimation {TranslateY = 700, Duration = "300"})
                        //    .ContinueWith(
                        //        x =>
                        //        {
                        //            titleControl.IsVisible = false;
                        //        });
                  

                    }


                    //await currentPage.MainContentView.Animate(new TranslateToAnimation
                    //{
                    //    TranslateY = 700,
                    //    Duration = "300"
                    //});
                    
                    currentPage.StackNavigation.Add((BaseContentView) oldValue);
                    currentPage.MainContentView.Content = newValue;
                    //await currentPage.MainContentView.Animate(new TranslateToAnimation
                    //{
                    //    TranslateY = 0,
                    //    Duration = "300"
                    //});
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }


        protected override bool OnBackButtonPressed()
        {
            if (StackNavigation.Count > 0)
            {
                var menu = ((App) Application.Current).StartMenu;
                var startMenu = ContentViewModelResolver.ResolveViewModel((object) null,
                   menu);
                var dynamicContent = FreshIOC.Container.Resolve<IDynamicContent>();
                dynamicContent.MainContentView = startMenu;
                StackNavigation.Clear();
            }
            else
            {
                INativeHelper nativeHelper = null;
                nativeHelper = DependencyService.Get<INativeHelper>();
                if (nativeHelper != null)
                    nativeHelper.CloseApp();
                base.OnBackButtonPressed();
            }
            return true;
        }

        protected override void OnAppearing()
        {
            //Menu.MenuListView.HeaderTemplate = null;

            base.OnAppearing();
        }
    }
}