using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using RestaurantApp.Droid.Renderers;
using RestaurantApp.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;
using WebView = Xamarin.Forms.WebView;

[assembly: ExportRenderer(typeof(TransparentWebView), typeof(TransparentWebViewRenderer))]
namespace RestaurantApp.Droid.Renderers
{
    public class TransparentWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);
            CustomWebClient customWebViewClient = new CustomWebClient();
            this.Control.SetBackgroundColor(Color.Transparent.ToAndroid());
            this.Control.SetWebViewClient(customWebViewClient);
            customWebViewClient.PageLoading += CustomWebViewClient_PageLoading;
            customWebViewClient.PageFinished += CustomWebViewClient_PageFinished; ; 

        }

        private void CustomWebViewClient_PageFinished(object sender, string e)
        {
            ((TransparentWebView)Element).OnPageFinished(e);
        }

        private void CustomWebViewClient_PageLoading(object sender, string e)
        {
            ((TransparentWebView) Element).OnPageStarted(e);
        }
    }

    class CustomWebClient : WebViewClient
    {
        public event EventHandler<string> PageLoading;
        public event EventHandler<string> PageFinished;
        public override void OnPageStarted(Android.Webkit.WebView view, string url, Bitmap favicon)
        {
            base.OnPageStarted(view, url, favicon);

            //fire result Event
            if (PageLoading != null)
                PageLoading(this, url);
        }

        public override void OnPageFinished(Android.Webkit.WebView view, string url)
        {
            base.OnPageFinished(view, url);
            //fire result Event
            if (PageFinished != null)
                PageFinished(this, url);
        }
    }
}