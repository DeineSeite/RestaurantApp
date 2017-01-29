using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using RestaurantApp.Core.Localization;
using Xamarin.Forms;

namespace RestaurantApp.Core.PageModels
{
   public class AccountPageModel: BasePageModel
    {
      
        public AccountPageModel()
        {
            Title = AppResources.Account;
        }

       
    }
}
