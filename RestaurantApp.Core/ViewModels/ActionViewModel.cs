using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Util;
using Android.Views;
using PropertyChanged;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Services;
using RestaurantApp.Data.Models;
using Xamarin.Forms;

namespace RestaurantApp.Core.ViewModels
{
    [ImplementPropertyChanged]
  public  class ActionViewModel:BaseViewModel
    {
        public  ObservableCollection<ActionModel> ActionsList { get; set; }

        public ActionViewModel()
        {
            ActionTappedCommand = new Command<ActionModel>(ActionTapped);
            ActionsList=new ObservableCollection<ActionModel>(DataAccess.GetAllActions());
      
        }

        public Command<ActionModel> ActionTappedCommand { get; set; }


        void ActionTapped(ActionModel model)
        {
            DisplayService.DisplayAlert(model.Title,model.Description);
        }
    }
}
