using System;
using FreshMvvm;
using RestaurantApp.ContentViews;
using RestaurantApp.Core.Interfaces;
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

            this.SetBinding(MainContentProperty, "MainContentView");
        }

        public BaseContentView MainContent
        {
            get { return (BaseContentView) GetValue(MainContentProperty); }
            set { SetValue(MainContentProperty, value); }
        }


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

                    await currentPage.MainContentView.Animate(new TranslateToAnimation
                    {
                        Duration = "300",
                        TranslateX = 700
                    });
                    currentPage.MainContentView.TranslationX = -700;
                    currentPage.MainContentView.Content = newValue;
                    await currentPage.MainContentView.Animate(new TranslateToAnimation
                    {
                        Duration = "300",
                        TranslateX = 0
                    });
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        protected override bool OnBackButtonPressed()
        {
            var contentService = FreshIOC.Container.Resolve<IContentNavigationService>();
            contentService.StepBackNavigation();
            return true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}