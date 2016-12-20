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
        public BasePageModel()
      {
        
      }
    }
}
