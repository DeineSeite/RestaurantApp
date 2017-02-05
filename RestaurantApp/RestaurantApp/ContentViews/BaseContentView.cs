using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using Xamarin.Forms;

namespace RestaurantApp.ContentViews
{
    public class BaseContentView : ContentView, IBaseContentView
    {
        
        public BaseContentView()
        {
              var app = FreshIOC.Container.Resolve<IApplicationContext>();
              var backgroundColor = (Color) app.Instance.Resources["SecondThemeColorAlpha80"];
              BackgroundColor = backgroundColor;
        }

        public string Title { get; set; }
        public string SubTitle { get; set; }

        public new object BindingContext
        {
            get { return base.BindingContext; }
            set { base.BindingContext = value; }
        }
    }
}