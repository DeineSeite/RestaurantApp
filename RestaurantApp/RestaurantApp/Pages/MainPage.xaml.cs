using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreshMvvm;
using RestaurantApp.ContentViews;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using RestaurantApp.Core.ViewModels;
using RestaurantApp.UserControls;
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
                       
                        //Set Title and Subtitle text for current view
                        titleControl.TitleText = ((BaseContentView) newValue).Title.ToUpper();
                        titleControl.SubTitleText = ((BaseContentView) newValue).SubTitle;
                       
                    }
                    else
                    {
                      titleControl.IsVisible = false;

                    
                    }

                    if (currentPage.StackNavigation.Count <2)
                    {
                        currentPage.StackNavigation.Add((BaseContentView) oldValue);
                    }
                    currentPage.MainContentView.Content = newValue;
                    



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
                MainContent= StackNavigation[1];
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