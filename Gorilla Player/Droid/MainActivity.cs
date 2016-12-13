using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FreshMvvm;
using RestaurantApp.Pages;

namespace UXDivers.Gorilla.Droid
{
	[Activity (Label = "Gorilla Player", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
            LoadApplication(UXDivers.Gorilla.Droid.Player.CreateApplication(ApplicationContext,
              new UXDivers.Gorilla.Config("Good Gorilla")
                .RegisterAssemblyFromType<BasePage>()
                  .RegisterAssemblyFromType<FreshBaseContentPage>()
                  .RegisterAssemblyFromType<FreshBasePageModel>()
              ));
           
		}

		public override bool OnKeyUp (Keycode keyCode, KeyEvent e)
		{
			if ((keyCode == Keycode.Menu || keyCode == Keycode.F1) && Coordinator.Instance != null) {
				Coordinator.Instance.RequestStatusUpdate ();
				return true; 
			}

			return base.OnKeyUp (keyCode, e); 
		} 
	}
}

