using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DLToolkit.Forms.Controls;
using RestaurantApp.Core.Converters;
using RestaurantApp.Droid.Renderers;
using RestaurantApp.Pages;
using RestaurantApp.Triggers;
using RestaurantApp.UserControls;
using UXDivers.Gorilla;
using Xamarin.Forms;


namespace RestaurantApp.Droid
{
    [Activity(Label = "RestaurantApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
       
            global::Xamarin.Forms.Forms.Init(this, bundle);
            FlowListView.Init();
#if !GORILLA
            LoadApplication(new App());
#else
              LoadApplication(UXDivers.Gorilla.Droid.Player.CreateApplication(ApplicationContext, config: new UXDivers.Gorilla.Config("Good Gorilla")
              .RegisterAssemblyFromType<BasePage>()
              .RegisterAssemblyFromType<AlphaColorConverter>()
              .RegisterAssemblyFromType<IValueConverter>()
              .RegisterAssemblyFromType<RoundedBox>()
              .RegisterAssemblyFromType<RoundedBoxRenderer>()
              .RegisterAssemblyFromType<MenuItemClickTrigger>()
              .RegisterAssemblyFromType<UserControls.GridView>()
              .RegisterAssemblyFromType<FlowListView>()
              .RegisterAssemblyFromType<StringCaseConverter>()
              ));
#endif
        }
        public override bool OnKeyUp(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            if (keyCode == Android.Views.Keycode.F1 && Coordinator.Instance != null)
            {
                Coordinator.Instance.RequestStatusUpdate();
                return true;
            }

            return base.OnKeyUp(keyCode, e);
        }
    }
}

