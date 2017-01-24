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
        public bool IsActive
        {
            get { return ActiveImage.IsVisible; }
            set { ActiveImage.IsVisible = value; }
        }

        public BonusPointItemTemplate()
        {
            InitializeComponent();
          
          
           
        }

   
   
    }
}
