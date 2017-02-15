using System.Diagnostics;
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
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
            }
        }
        private bool _isBusy;
       
        #endregion

        #region ctor

        public override void Init(object initData)
        {
            GoBackCommand = new Command(GoBack);
          
            IsBusy = false;
            PropertyChanged += BasePageModel_PropertyChanged;
        }

        private void BasePageModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
#if DEBUG
            Debug.WriteLine("DEBUG: Property Changed "+e.PropertyName);
#endif
        }

        #endregion

        #region Commands

        public Command GoBackCommand { get; set; }
      

        #endregion

        #region Methods

       

        private void GoBack()
        {
        
        }

        #endregion

        #region Private members

        private string _title;
        private string _subTitle;

        

        #endregion
    }
}