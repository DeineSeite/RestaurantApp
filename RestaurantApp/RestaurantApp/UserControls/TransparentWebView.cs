using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using Xamarin.Forms;

namespace RestaurantApp.UserControls
{
   public class TransparentWebView:WebView
   {
       private IDynamicContent mainContent;
        
        public TransparentWebView()
        {
            mainContent = FreshIOC.Container.Resolve<IDynamicContent>();

            Navigating += TransparentWebView_Navigating;
            Navigated += TransparentWebView_Navigated;
        }

        private void TransparentWebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            mainContent.IsBusy = true;
        }

        private void TransparentWebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            Eval("AppHidden()");
            mainContent.IsBusy = true;
        }
    }
}
