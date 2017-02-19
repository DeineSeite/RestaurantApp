using System.Reflection;
using Android.App;
using Android.Content.PM;
using Android.OS;
using DLToolkit.Forms.Controls;
using Microsoft.Azure.Mobile;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
#if  GORILLA
using UXDivers.Gorilla;
using UXDivers.Gorilla.Droid;
#endif


[assembly: Application(Debuggable = true)]

namespace RestaurantApp.Droid
{
    [Activity(Label = "RestaurantApp",
#if GORILLA
        Icon = "@drawable/iconGorilla",
#else
      Icon = "@drawable/icon", 
#endif
        Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            FlowListView.Init();
            MobileCenter.Configure("8844801f-c2a9-4e09-b769-61856cfc7d1a");
#if !GORILLA
            LoadApplication(new App());
#else
            LoadApplication(Player.CreateApplication(ApplicationContext, new Config("Good Gorilla")
                .RegisterAssemblyFromType<BasePage>()
                .RegisterAssemblyFromType<AlphaColorConverter>()
                .RegisterAssemblyFromType<IValueConverter>()
                .RegisterAssemblyFromType<RoundedBox>()
                .RegisterAssemblyFromType<CircleImage>()
                .RegisterAssemblyFromType<CircleImageRenderer>()
                .RegisterAssemblyFromType<RoundedBoxRenderer>()
                .RegisterAssemblyFromType<MenuItemClickTrigger>()
                .RegisterAssemblyFromType<GridView>()
                .RegisterAssemblyFromType<FlowListView>()
                .RegisterAssemblyFromType<StringCaseConverter>()
                .RegisterAssemblyFromType<HtmlLabelRenderer>()
                .RegisterAssemblyFromType<InverseBooleanConverter>()
                .RegisterAssemblyFromType<InverseBooleanConverter>()
                .RegisterAssemblyFromType<BaseContentView>()
            ));
#endif
        }

#if GRILLA

        public override bool OnKeyUp(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            if (keyCode == Android.Views.Keycode.F1 && Coordinator.Instance != null)
            {
                Coordinator.Instance.RequestStatusUpdate();
                return true;
            }

            return base.OnKeyUp(keyCode, e);
        }
                
#endif
    }
}