using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;

namespace RestaurantApp.Services
{
   public class RestaurantAppPageModelMapper : IFreshPageModelMapper
    {
        public string GetPageTypeName(Type pageModelType)
        {
           var s= pageModelType.AssemblyQualifiedName
                  .Replace("RestaurantApp.Core", "RestaurantApp")
                  .Replace("RestaurantApp.Core.PageModels", "RestaurantApp.Pages")
                  .Replace("PageModel", "Page");
            return s;
            // .Replace("PageModel", "Page")

        }
    }
}

 