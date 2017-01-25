using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Converters;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
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
            App.IsLastItemAdded = false;
            FlowList.ForceReload();
           
        }
    }
}
