using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.PageModels
{
   public class OpenHoursPageModel:BasePageModel
    {
        public  string HtmlContent { get; set; }
       public  RestaurantModel Restaurant { get; set; }
        public OpenHoursPageModel()
        {

           Restaurant=new RestaurantModel();
            Restaurant.Phone = "01/256 89 80";
            Restaurant.Email = "lokal@luckywok.at";
            Restaurant.Street = "Wagramer Strasse 189b";
            Restaurant.PostalCode = "1210";
            Restaurant.City = "Wien";


        }
    }
}
