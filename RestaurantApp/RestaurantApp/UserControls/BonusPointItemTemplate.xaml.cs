using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RestaurantApp.UserControls
{
    public partial class BonusPointItemTemplate : ContentView
    {
        public bool IsScannItemActived
        {
            get { return ScannImage.IsVisible; }
            set { ScannImage.IsVisible = value; }
        }
        public BonusPointItemTemplate()
        {
            InitializeComponent();
          
          
           
        }

   
   
    }
}
