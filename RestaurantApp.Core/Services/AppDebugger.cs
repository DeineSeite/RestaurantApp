using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.Interfaces;
using Xamarin.Forms;

namespace RestaurantApp.Core.Services
{
    public class AppDebugger
    {
        public static void WriteLine(string message)
        {
            IDebugger debugger = DependencyService.Get<IDebugger>(DependencyFetchTarget.GlobalInstance);
            debugger.WriteLine(message);
        }
    }
}
