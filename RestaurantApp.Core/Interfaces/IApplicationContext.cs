using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using Xamarin.Forms;

namespace RestaurantApp.Core.Interfaces
{
    public interface IApplicationContext
    {
       
        void ChangeCurrentCultureInfo(string langCode);
        CultureInfo CurrentCulture { get; set; }
       
        
    }
}
