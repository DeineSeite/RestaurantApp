using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantApp.iOS.Renderers;
using RestaurantApp.UserControls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TransparentWebView), typeof(TransparentWebViewRenderer))]
namespace RestaurantApp.iOS.Renderers
{
    public class TransparentWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            this.Opaque = false;
            this.BackgroundColor = UIColor.Clear;
            
        }
    }
}