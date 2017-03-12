using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using DLToolkit.Forms.Controls;
using Microsoft.Azure.Mobile;
using Xamarin.Forms;
using Animation = Android.Views.Animations.Animation;

namespace RestaurantApp.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : AppCompatActivity
    {
        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            //Task startupWork = new Task(Startup);
            //startupWork.Start();
        }
        // Simulates background work that happens behind the splash screen
        //void Startup()
        //{
        //   var imgView = (ImageView)FindViewById(Resource.Id.splashScreenImageView);
        //    var animation1 = AnimationUtils.LoadAnimation(this, Resource.Animation.rotate);
        //    var animation2 = AnimationUtils.LoadAnimation(this, Resource.Animation.antirotate);
        //    var animation3 = AnimationUtils.LoadAnimation(this, Resource.Animation.abc_fade_out);
        //    imgView.StartAnimation(animation2);
        //    animation1.AnimationEnd += delegate
        //    {
        //       // imgView.StartAnimation(animation3);
               
        //    };
        //    animation2.AnimationEnd += delegate
        //    {
        //        imgView.StartAnimation(animation1);
        //    };
        //}
      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ThreadPool.QueueUserWorkItem(o => Init(savedInstanceState));
            SetContentView(Resource.Layout.splashscreenmaker);
            StartAnimations();
            
        }

        private async void Init(Bundle bundle)
        {
           await Task.Run(() => {
                Forms.Init(this, bundle);
                Xamarin.FormsGoogleMaps.Init(this, bundle);
                FlowListView.Init();
                MobileCenter.Configure("8844801f-c2a9-4e09-b769-61856cfc7d1a");
            });
        }
        private void StartAnimations()
        {
            Animation anim = AnimationUtils.LoadAnimation(this, Resource.Animation.alpha);
            anim.Reset();
            LinearLayout l = (LinearLayout)FindViewById(Resource.Id.lin_lay);
            l.ClearAnimation();
            l.StartAnimation(anim);
            Animation anim2 = AnimationUtils.LoadAnimation(this, Resource.Animation.translate);
            anim2.Reset();
            ImageView iv = (ImageView)FindViewById(Resource.Id.logo);
            iv.ClearAnimation();
            iv.StartAnimation(anim2);
            iv.Animation.AnimationEnd += Animation_AnimationEnd;
         
           

        }

        private void Animation_AnimationEnd(object sender, Animation.AnimationEndEventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
            Finish();
        }

        
    }

}
