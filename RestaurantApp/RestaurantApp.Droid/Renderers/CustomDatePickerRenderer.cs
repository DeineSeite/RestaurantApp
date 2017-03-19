using System.ComponentModel;
using RestaurantApp.Droid.Renderers;
using RestaurantApp.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]

namespace RestaurantApp.Droid.Renderers
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null && Element is ICanBeValidated)
            {
                Control.Text = (Element as CustomDatePicker).PlaceHolder;
                Control.SetTextColor(Control.HintTextColors);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName=="Date") Control.SetTextColor(Android.Graphics.Color.Black);
        }
    }
}