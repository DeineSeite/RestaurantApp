using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using DLToolkit.Forms.Controls;
using Java.Lang;
using Microsoft.Azure.Mobile;
using Xamarin.Forms;
using Animation = Android.Views.Animations.Animation;

namespace RestaurantApp.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : Activity
    {
        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
          //  StartAnimations();
        }
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
           
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.splashscreenmaker);
            Forms.Init(this, savedInstanceState);
            MobileCenter.Configure("8844801f-c2a9-4e09-b769-61856cfc7d1a");
            StartActivity(typeof(MainActivity));
            Finish();
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);
            FlowListView.Init();
            
            // StartAnimations();
            //  Log.Debug("GASTRO APP", "1");
            // ThreadPool.QueueUserWorkItem(o => Init(savedInstanceState));
        }

        //private async void Init(Bundle bundle)
        //{
        //   await Task.Run(() => {
        //        Forms.Init(this, bundle);
        //       StartActivity(typeof(MainActivity));
        //       Xamarin.FormsGoogleMaps.Init(this, bundle);
        //        FlowListView.Init();
        //        MobileCenter.Configure("8844801f-c2a9-4e09-b769-61856cfc7d1a");
        //       Finish();
        //   });
        //}
        private void StartAnimations()
        {
            ImageView iv = (ImageView)FindViewById(Resource.Id.logo);
            iv.Visibility=ViewStates.Gone;
            LinearLayout linear = (LinearLayout) FindViewById(Resource.Id.lin_lay);
            LayerDrawable progressAnimationLeft = (LayerDrawable)linear.Background;

 
            
            //   ((Android.Graphics.Drawables.IAnimatable)progressAnimationLeft.GetDrawable(1)).Start();
            //Animation anim2 = AnimationUtils.LoadAnimation(this, Resource.Animation.rotate);
            //anim2.Reset();
            // iv.Visibility =ViewStates.Visible;

            //iv.ClearAnimation();
            //  iv.StartAnimation(anim2);
            //  iv.Animation.AnimationEnd += Animation_AnimationEnd;
        }

        private void Animation_AnimationEnd(object sender, Animation.AnimationEndEventArgs e)
        {
            StartActivity(typeof(MainActivity));
            Finish();
        }

        
    }

}
