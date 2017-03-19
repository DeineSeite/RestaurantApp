using System.ComponentModel;
using RestaurantApp.iOS.Renderers;
using RestaurantApp.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(CustomTimePickerRenderer))]

namespace RestaurantApp.iOS.Renderers
{
    public class CustomTimePickerRenderer : TimePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null && Element is ICanBeValidated)
            {
                Control.Text = (Element as CustomTimePicker).PlaceHolder;
                Control.TextColor = Color.FromHex("#C7C7CD").ToUIColor();
            }

        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Time") Control.TextColor = Color.Black.ToUIColor();
        }
    }
}