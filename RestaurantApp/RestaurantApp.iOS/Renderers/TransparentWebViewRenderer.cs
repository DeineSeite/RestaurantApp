using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace RestaurantApp.iOS.Renderers
{
    public class TransparentWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            this.Opaque = false;
            this.BackgroundColor = Color.Transparent.ToUIColor();
        }
    }
}