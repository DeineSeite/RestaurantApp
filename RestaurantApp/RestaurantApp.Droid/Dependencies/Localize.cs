using System;
using System.Threading;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Droid.Dependencies;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace RestaurantApp.Droid.Dependencies
{
    public class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            return ((IApplicationContext)Xamarin.Forms.Application.Current).CurrentCulture;
        }

        public void SetLocale()
        {
            new NotImplementedException("Set Locale without parameter is not implemented in Android");
        }

        public void SetLocale(string langCode)
        {
            var netLocale = langCode.ToString().Replace("_", "-");
            var ci = new System.Globalization.CultureInfo(netLocale);

            ((IApplicationContext)Xamarin.Forms.Application.Current).CurrentCulture = ci;

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}