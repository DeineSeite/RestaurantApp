using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FAB.Forms;
using FreshMvvm;
using Plugin.Share;
using Plugin.Share.Abstractions;
using RestaurantApp.ContentViews;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Localizations;
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

        private FloatingActionButton FabButton;

        public MainPage()
        {
            InitializeComponent();

            this.SetBinding(MainContentProperty, "MainContentView");
            IsBusy = true;
            Task.Run(() =>
                {
                    AddFloatButtonToLayout();
                    AddLikeButton();
                }
            );
        }

        public BaseContentView MainContent
        {
            get { return (BaseContentView) GetValue(MainContentProperty); }
            set { SetValue(MainContentProperty, value); }
        }

        public void FloadButtonVisibility(bool visible)
        {
            FabButton.IsVisible = visible;
        }
        public void LikeButtonVisibility(bool visible)
        {
            FabButton.IsVisible = visible;
        }

        private TransparentWebView _likeView;
        private void AddLikeButton()
        {
            _likeView = new TransparentWebView();
            var source = new HtmlWebViewSource();
            source.Html = @"<html>
                           <head> 
                           </head>
                           <body>
                           <iframe src=""http://www.facebook.com/plugins/like.php?href=https://www.facebook.com/gastroappdeineseite&amp;send=false&amp;layout=button_count&amp;width=450&amp;show_faces=false&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21"" 
                                   scrolling=""no"" 
                                   frameborder=""0"" 
                                   style=""border:none; overflow:hidden; width:300px; ""
                                   allowTransparency=""true"">
                           </iframe>
                           </body>
                           </html>";
            _likeView.Source = source;
            AbsoluteLayout.SetLayoutBounds(_likeView, new Rectangle(.05, .95, 210, 30));
            AbsoluteLayout.SetLayoutFlags(_likeView, AbsoluteLayoutFlags.PositionProportional);
            MainLayout.Children.Add(_likeView);
        }

        private void AddFloatButtonToLayout()
        {
            FabButton = new FloatingActionButton();
            var backgroundColor = (Color) Application.Current.Resources["MainThemeColor"];
            FabButton.NormalColor = backgroundColor;
            FabButton.Source = "share.png";
            FabButton.Size = FabSize.Normal;
            var width = new OnIdiom<int>
            {
                Tablet = 80,
                Phone = 50
            };
            AbsoluteLayout.SetLayoutBounds(FabButton, new Rectangle(.95, .95, width, width));
            AbsoluteLayout.SetLayoutFlags(FabButton, AbsoluteLayoutFlags.PositionProportional);
            MainLayout.Children.Add(FabButton);
            FabButton.Clicked += delegate
            {
                var v = new ShareMessage();
                var email = Settings.UserEmail ?? Settings.UserId.ToString();
                v.Url = "http://www.gastro-app.com/download/download.php?file=com.restaurant.droid.apk&email=" + email;
                v.Title = AppResources.ShareWithFriend;
                v.Text = string.Format(AppResources.HiFriend, v.Url);
                CrossShare.Current.Share(v);
            };
        }


        private static async void ContentChanged(BindableObject obj, View oldValue, View newValue)
        {
            try
            {
                var currentPage = obj as MainPage;

                if (currentPage != null)
                {
                    var titleControl = currentPage.HeaderPage.TitleControl;
                    var isMenu = newValue.GetType() == typeof(MenuView);

                    //Hide Title if MenuView
                    titleControl.IsVisible = !isMenu;

                    //Hide FAButton and LikeButton if not MenuView
                    currentPage.FloadButtonVisibility(isMenu);
                    currentPage.LikeButtonVisibility(isMenu);

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