using FreshMvvm;
using PropertyChanged;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using RestaurantApp.Core.ViewModels;
using Xamarin.Forms;


namespace RestaurantApp.Core.PageModels
{
    [ImplementPropertyChanged]
    public class MainPageModel : BasePageModel,IDynamicContent
    {
        public IBaseContentView MainContentView
        {
            get;
            set;
        }

        #region ctor
        public MainPageModel()
        {
            GoToAccountCommand = new Command(GoToAccountPage);
        }

        #endregion

        public Command GoToAccountCommand { get; set; }

        private void GoToAccountPage()
        {
            var accountView = ContentViewModelResolver.ResolveViewModel<AccountViewModel>();
            var contentNavigation = FreshIOC.Container.Resolve<IContentNavigationService>();
            contentNavigation.PushContentView(accountView);
        }
    }
}