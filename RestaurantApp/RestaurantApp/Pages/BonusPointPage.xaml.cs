using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.UserControls;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace RestaurantApp.Pages
{
    public partial class BonusPointPage : BasePage,IListViewPage
    {


        public BonusPointPage()
        {
            InitializeComponent();
            FlowList.FlowColumnTemplate=new BonusPointDataTemplateSelector();
            
        }


        public override void ReloadListView()
        {
            
            FlowList.ForceReload();
           
        }

        private void RefreshButton_OnClicked(object sender, EventArgs e)
        {
            FlowList.IsRefreshing = true;
           
        }
    }
}
