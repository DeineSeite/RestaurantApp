using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantApp.Core.PageModels
{

  public class MainPageModel:FreshMvvm.FreshBasePageModel
    {
        public  string Test { get; set; }

        public MainPageModel()
        {
            Test = "HOHOH";
        }
    }
}
