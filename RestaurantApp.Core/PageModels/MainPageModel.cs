using PropertyChanged;
using RestaurantApp.Core.Interfaces;
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

        public bool IsBusy
        {
            get;
            set;
        }
        #region ctor
        public MainPageModel()
        {
            IsBusy = false;
        }
        
        #endregion
    }
}