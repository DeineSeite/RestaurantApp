using System;
using System.Diagnostics;
using FAB.Forms;
using FreshMvvm;
using Plugin.Share;
using Plugin.Share.Abstractions;
using RestaurantApp.ContentViews;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Data.Access;
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
            AddFloatButtonToLayout();

        }

        private FAB.Forms.FloatingActionButton FabButton;
        public void FloadButtonVisibility(bool visible)
        {
            FabButton.IsVisible = visible;
        }
        public void AddFloatButtonToLayout()
        {
            var normalFab = new FAB.Forms.FloatingActionButton();
            var backgroundColor = (Color)Application.Current.Resources["MainThemeColor"];
            normalFab.NormalColor = backgroundColor;
            normalFab.Source = "share.png";
            normalFab.Size = FabSize.Normal;
            var width = new OnIdiom<int>
            {
                Tablet = 80,
                Phone = 50
            };
            AbsoluteLayout.SetLayoutBounds(normalFab, new Rectangle(.95, .95, width, width));
            AbsoluteLayout.SetLayoutFlags(normalFab, AbsoluteLayoutFlags.PositionProportional);
            MainLayout.Children.Add(normalFab);
            normalFab.Clicked += delegate
            {
                var v = new ShareMessage();
                var email = Settings.UserEmail ?? Settings.UserId.ToString();
                v.Url = "http://www.gastro-app.com/download/download.php?file=com.restaurant.droid.apk&email="+email;
                v.Title = "Share with your friend";
                v.Text = $"hi friend, check this app ({v.Url}) and if you register (and by registration you put my email as recommender) I will get free point (stempel).";
                CrossShare.Current.Share(v);
            };

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