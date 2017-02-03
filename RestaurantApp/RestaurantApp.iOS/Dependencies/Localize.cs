using System;
using System.Globalization;
using System.Threading;
using Foundation;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.iOS.Dependencies;

[assembly: Xamarin.Forms.Dependency(typeof(Localize))]

namespace RestaurantApp.iOS.Dependencies
{
    public class Localize : ILocalize
    {
        public void SetLocale()
        {
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            var netLocale = iosLocaleAuto.Replace("_", "-");

            CultureInfo ci;

            try
            {
                ci = new CultureInfo(netLocale);
            }
            catch
            {
                ci = GetCurrentCultureInfo();
            }

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            Console.WriteLine("SetLocale: " + ci.Name);
        }


        public void SetLocale(string langCode)
        {
            var netLocale = langCode.Replace("_", "-");

            CultureInfo ci;

            try
            {
                ci = new CultureInfo(netLocale);
            }
            catch
            {
                ci = GetCurrentCultureInfo();
            }


            ((IApplicationContext) Xamarin.Forms.Application.Current).CurrentCulture = ci;

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }


        public CultureInfo GetCurrentCultureInfo()
        {
            return ((IApplicationContext) Xamarin.Forms.Application.Current).CurrentCulture;
        }
    }
}