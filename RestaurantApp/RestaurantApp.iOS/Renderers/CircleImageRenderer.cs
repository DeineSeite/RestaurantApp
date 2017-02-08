using System;
using System.ComponentModel;
using System.Diagnostics;
using RestaurantApp.iOS.Renderers;
using RestaurantApp.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CircleImage), typeof(CircleImageRenderer))]

namespace RestaurantApp.iOS.Renderers
{
    public class CircleImageRenderer : ImageRenderer
    {
        private void CreateCircle()
        {
            try
            {
                var min = Math.Min(Element.Width, Element.Height);
                Control.Layer.CornerRadius = (float) (min / 2.0);
                Control.Layer.MasksToBounds = false;
                Control.Layer.BorderColor = Color.White.ToCGColor();
                Control.Layer.BorderWidth = 3;
                Control.ClipsToBounds = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to create circle image: " + ex);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            CreateCircle();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName)
                CreateCircle();
        }
    }
}