using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.Services;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace RestaurantApp.Pages
{
    public partial class BonusPointPage : BasePage
    {
        class Test
        {
            public bool Active { get; set; }
        }

        public BonusPointPage()
        {
            InitializeComponent();
            List<Test> test = new List<Test>();
            for (int i = 0; i < 10; i++)
            {
                test.Add(new Test() {Active = i < 5});
            }
            FlowList.FlowItemsSource = test;
            var tap = new TapGestureRecognizer(x => ShowQrCodePage());
            QrCode.GestureRecognizers.Add(tap);
        }

        private async void ShowQrCodePage()
        {
           

        }

       
    }
}
