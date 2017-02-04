using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.ViewModels
{
  public  class OpenHoursViewModel:BaseViewModel
    {
        public RestaurantModel Restaurant { get; set; }

        public OpenHoursViewModel()
        {
            Restaurant = new RestaurantModel();
            Restaurant.Phone = "01/256 89 80";
            Restaurant.Email = "lokal@luckywok.at";
            Restaurant.Street = "Wagramer Strasse 189b";
            Restaurant.PostalCode = "1210";
            Restaurant.City = "Wien";

        }
    }
}
