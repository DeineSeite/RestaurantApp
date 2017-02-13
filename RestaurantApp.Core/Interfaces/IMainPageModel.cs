using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantApp.Core.Interfaces
{
   public interface IMainPageModel:IDynamicContent
   {
        Page CurrentPage { get; set; }
       
   }
}
