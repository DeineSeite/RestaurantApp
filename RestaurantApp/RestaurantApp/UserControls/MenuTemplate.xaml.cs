using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RestaurantApp.UserControls
{
    public partial class MenuTemplate : ContentView
    {
        public ListView MenuListView { get { return MenuList; } set { MenuList = value; } }
        public MenuTemplate()
        {
            InitializeComponent();
        }


        
    }
}
