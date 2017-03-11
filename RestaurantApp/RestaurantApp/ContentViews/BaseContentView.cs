using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using Xamarin.Forms;

namespace RestaurantApp.ContentViews
{
    public abstract class BaseContentView : ContentView, IBaseContentView
    {
        public virtual void OnAppearing(Page parentPage)
        {
            
        }
        
        public BaseContentView()
        {
#if !GORILLA
              var backgroundColor = (Color) Application.Current.Resources["SecondThemeColorAlpha80"];
              BackgroundColor = backgroundColor;
#endif
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