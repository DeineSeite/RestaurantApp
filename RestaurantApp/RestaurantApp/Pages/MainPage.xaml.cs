using System;
using System.Diagnostics;
using FreshMvvm;
using RestaurantApp.ContentViews;
using RestaurantApp.Core.Interfaces;
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

            this.SetBinding(MainContentProperty, "MainContentView");
            IsBusy = true;
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
                    titleControl.IsVisible = newValue.GetType() != typeof(MenuView);

                    //Set Title and Subtitle text for current view
                    titleControl.TitleText = ((BaseContentView) newValue).Title?.ToUpper();
                    titleControl.SubTitleText = ((BaseContentView) newValue).SubTitle;

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

                    //bug with WebView is not showing in StackLayout , workaround:
                    if (((ContentView) newValue).Content is TransparentWebView)
                        currentPage.MainContentView.VerticalOptions = LayoutOptions.FillAndExpand;
                    else
                        currentPage.MainContentView.VerticalOptions = LayoutOptions.Start;
                    //---------------------------------------------------------
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Change ContentView Exception " + e.Message);
            }
        }


        protected override bool OnBackButtonPressed()
        {
            var contentService = FreshIOC.Container.Resolve<IContentNavigationService>();
            if (contentService.StepBackNavigation())
                return true;

            base.OnBackButtonPressed();
            return false;
        }
    }
}