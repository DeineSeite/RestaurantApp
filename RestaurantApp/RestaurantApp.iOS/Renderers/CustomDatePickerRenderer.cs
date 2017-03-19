using System.ComponentModel;
using RestaurantApp.iOS.Renderers;
using RestaurantApp.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]

namespace RestaurantApp.iOS.Renderers
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null && Element is ICanBeValidated)
            {
                Control.Text = (Element as CustomDatePicker).PlaceHolder;
                Control.TextColor = Color.FromHex("#C7C7CD").ToUIColor();
            }

        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Date") Control.TextColor=Color.Black.ToUIColor();
        }
    }
}