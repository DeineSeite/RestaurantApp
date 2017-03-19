using System;
using System.ComponentModel;
using RestaurantApp.Droid.Renderers;
using RestaurantApp.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(CustomTimePickerRenderer))]
namespace RestaurantApp.Droid.Renderers
{
    public class CustomTimePickerRenderer : TimePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null && Element is ICanBeValidated)
            {
                Control.Text = (Element as CustomTimePicker).PlaceHolder;
                Control.SetTextColor(Control.HintTextColors);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Time") Control.SetTextColor(Android.Graphics.Color.Black);
        }
    }
}