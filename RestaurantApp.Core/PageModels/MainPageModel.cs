using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace RestaurantApp.Core.PageModels
{
    [ImplementPropertyChanged]
  public class MainPageModel:FreshMvvm.FreshBasePageModel
    {
        public  string Test { get; set; }

        public MainPageModel()
        {
            Test = "HOHOH";
        }
    }
}
