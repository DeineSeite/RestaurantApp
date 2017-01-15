using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RestaurantApp.Pages
{
    public partial class GalleryPage : BasePage
    {
        public GalleryPage()
        {
            InitializeComponent();
            GalWebView.Navigated += GalWebView_Navigated;
            GalWebView.Navigating += GalWebView_Navigating;
            GalWebView.PropertyChanged += GalWebView_PropertyChanged;
        }

        private void GalWebView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }

        private void GalWebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
      
        }

        private void GalWebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            GalWebView.Eval("AppHidden()");
        }
    }
}
