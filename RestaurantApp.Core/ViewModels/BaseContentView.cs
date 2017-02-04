using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using Xamarin.Forms;

namespace RestaurantApp.Core.ViewModels
{
   public class BaseContentView:ContentView
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public BaseContentView()
        {
           var app = FreshIOC.Container.Resolve<IApplicationContext>();
           
        }
    }
}
