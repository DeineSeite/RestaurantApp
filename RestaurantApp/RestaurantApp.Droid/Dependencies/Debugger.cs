using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Droid.Dependencies;

[assembly: Xamarin.Forms.Dependency(typeof(Debugger))]
namespace RestaurantApp.Droid.Dependencies
{
    public class Debugger : IDebugger
    {
        public void WriteLine(string message)
        {
            Android.Util.Log.Debug("RestaurantApp", message);
        }
    }
}