using System;
using System.Collections.Generic;
using System.Linq;
using DLToolkit.Forms.Controls;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using RestaurantApp.iOS.Renderers;
using RestaurantApp.Pages;
using RestaurantApp.Triggers;
using RestaurantApp.UserControls;
using UIKit;

namespace RestaurantApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
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
            global::Xamarin.Forms.Forms.Init();
            FlowListView.Init();
            ImageCircleRenderer.Init();

#if !GORILLA
            LoadApplication(new App());
#else
            LoadApplication(UXDivers.Gorilla.iOS.Player.CreateApplication(
                new UXDivers.Gorilla.Config("Good Gorilla")
                .RegisterAssemblyFromType<BasePage>()
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
