using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using PropertyChanged;
using Xamarin.Forms;

namespace RestaurantApp.Core.PageModels
{
    [ImplementPropertyChanged]
  public  class BasePageModel : FreshMvvm.FreshBasePageModel
    {
        /// <summary>
        /// Set title for ContentPage
        /// </summary>
        public string Title {
            get { return _title; }
            set
            {
                _title = value;
                if (CurrentPage != null) CurrentPage.Title = _title;
            }
        }

        public override void Init(object initData)
        {
            CurrentPage.Title = _title;
            GoBackCommand = new Command(GoBack);
        }
        public Command GoBackCommand { get; set; }

        private void GoBack()
        {
            CurrentPage.SendBackButtonPressed();
        }
        public BasePageModel()
      {
       
      }
        #region Private members

        string _title;

        #endregion
    }
}
