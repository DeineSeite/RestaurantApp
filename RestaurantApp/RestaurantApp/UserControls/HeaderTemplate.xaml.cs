using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RestaurantApp.UserControls
{
    public partial class HeaderTemplate : ContentView
    {
        public TitleTemplate TitleControl
        {
            get { return Title; }
            set { Title = value; }
        }
        public HeaderTemplate()
        {
            InitializeComponent();
           var tapGesture=new TapGestureRecognizer();
            tapGesture.Tapped += BackGesture_Tapped;
            
        }

        private void BackGesture_Tapped(object sender, EventArgs e)
        {
          
        }

        private void GoBack()
        {
            
        }
    }
}
