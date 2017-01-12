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
        public MenuTemplate()
        {
            InitializeComponent();
            MenuListView.ItemAppearing += MenuListView_ItemAppearing;
        }

        private void MenuListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var s = sender;
        }
    }
}
