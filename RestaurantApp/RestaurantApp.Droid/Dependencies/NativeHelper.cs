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

[assembly: Xamarin.Forms.Dependency(typeof(NativeHelper))]
namespace RestaurantApp.Droid.Dependencies
{
    public class NativeHelper : INativeHelper
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }

}