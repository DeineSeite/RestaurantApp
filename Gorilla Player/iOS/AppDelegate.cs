using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

using Foundation;
using FreshMvvm;
using RestaurantApp.Pages;
using UIKit;

[assembly: ExportRenderer(typeof(Page), typeof(UXDivers.Gorilla.ShakeDetectionRenderer))]
namespace UXDivers.Gorilla.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

            // Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
            ///Xamarin.Calabash.Start();
#endif

            //LoadApplication (Player.CreateApplication(new Config("Gorilla on DESKTOP-KJQN2N8")));
            LoadApplication(UXDivers.Gorilla.iOS.Player.CreateApplication(
              new UXDivers.Gorilla.Config("Good Gorilla")
                  .RegisterAssemblyFromType<BasePage>()
                  .RegisterAssemblyFromType<FreshBaseContentPage>()
                  .RegisterAssemblyFromType<FreshBasePageModel>()));
            return base.FinishedLaunching (app, options);
		}

		public override void DidEnterBackground (UIApplication uiApplication)
		{
			base.DidEnterBackground (uiApplication);
		}
	}
}

