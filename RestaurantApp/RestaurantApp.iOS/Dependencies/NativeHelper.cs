using System.Diagnostics;
using RestaurantApp.Core.Interfaces;
using Xamarin.Forms.PlatformConfiguration;

namespace RestaurantApp.iOS.Dependencies
{
    public class NativeHelper : INativeHelper
    {
        public void CloseApp()
        {
            Process.GetCurrentProcess().CloseMainWindow();
            Process.GetCurrentProcess().Close();
        }
    }
}