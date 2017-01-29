using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantApp.UserControls
{
   public class TransparentWebView:WebView
    {
        public TransparentWebView()
        {
            Navigated += TransparentWebView_Navigated;
        }

        private void TransparentWebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
                Eval("AppHidden()");
        }
    }
}
