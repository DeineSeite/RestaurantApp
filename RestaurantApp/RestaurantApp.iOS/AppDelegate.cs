using DLToolkit.Forms.Controls;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace RestaurantApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            FlowListView.Init();

#if !GORILLA
            LoadApplication(new App());
#else
            LoadApplication(UXDivers.Gorilla.iOS.Player.CreateApplication(
                new UXDivers.Gorilla.Config("Good Gorilla")
                .RegisterAssemblyFromType<BasePage>()
             .RegisterAssemblyFromType<CircleImage>()
            .RegisterAssemblyFromType<CircleImageRenderer>()
                .RegisterAssemblyFromType<AlphaColorConverter>()
                .RegisterAssemblyFromType<RoundedBox>()
                .RegisterAssemblyFromType<RoundedBoxRenderer>()
                .RegisterAssemblyFromType<GradientContentView>()
                .RegisterAssemblyFromType<GradientContentViewRenderer>()
                .RegisterAssemblyFromType<TransparentWebView>()
                .RegisterAssemblyFromType<TransparentWebViewRenderer>()
                .RegisterAssemblyFromType<MenuItemClickTrigger>()
                .RegisterAssemblyFromType<GridView>()
                .RegisterAssemblyFromType<FlowListView>()
                .RegisterAssemblyFromType<StringCaseConverter>()
                .RegisterAssemblyFromType<HtmlLabelRenderer>()
                ));
#endif

            return base.FinishedLaunching(app, options);
        }
    }
}