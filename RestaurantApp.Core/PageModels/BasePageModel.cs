using FreshMvvm;
using PropertyChanged;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using RestaurantApp.Core.ViewModels;
using Xamarin.Forms;

namespace RestaurantApp.Core.PageModels
{
    [ImplementPropertyChanged]
    public class BasePageModel : FreshBasePageModel
    {
        #region Public properties

        /// <summary>
        ///     Set title for ContentPage
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                if (CurrentPage != null) CurrentPage.Title = _title;
            }
        }


        /// <summary>
        ///     Addition Title for ContentPage, will be shown under main Title
        /// </summary>
        public string SubTitle
        {
            get { return _subTitle; }
            set
            {
                _subTitle = value;
                if (CurrentPage != null) ((IBasePage) CurrentPage).SubTitle = _subTitle;
            }
        }

        #endregion

        #region ctor

        public override void Init(object initData)
        {
            CurrentPage.Title = _title;
            GoBackCommand = new Command(GoBack);
            GoToAccountCommand = new Command(GoToAccountPage);
        }

        #endregion

        #region Commands

        public Command GoBackCommand { get; set; }
        public Command GoToAccountCommand { get; set; }

        #endregion

        #region Methods

        private async void GoToAccountPage()
        {
            var accountView = ContentViewModelResolver.ResolveViewModel<AccountViewModel>();

         
        }

        private void GoBack()
        {
            var app = FreshIOC.Container.Resolve<IApplicationContext>();
            CoreMethods.PushPageModel<MainPageModel>();
            // ((IBasePage) CurrentPage)?.GoBackButton();
        }

        #endregion

        #region Private members

        private string _title;
        private string _subTitle;

        #endregion
    }
}