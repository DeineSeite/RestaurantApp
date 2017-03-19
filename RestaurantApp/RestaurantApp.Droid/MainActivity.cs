
using System.Diagnostics;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.Gms.Common;
using Android.OS;
using DLToolkit.Forms.Controls;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Plugin.Share;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


#if  GORILLA
using UXDivers.Gorilla;
using UXDivers.Gorilla.Droid;
#endif
namespace RestaurantApp.Droid
{
    [Activity(Label = "Gastro app",
#if GORILLA
        Icon = "@drawable/iconGorilla",
#else
      Icon = "@drawable/icon", 
#endif
        Theme = "@style/MainTheme",
        MainLauncher = false,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
       
           TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            var s = CrossShare.Current;
          
#if !GORILLA
            var watch = Stopwatch.StartNew();
            LoadApplication(new App());
            watch.Stop();
            MobileCenterLog.Debug("GASTRO", "Start time: " + watch.ElapsedMilliseconds);
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