using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

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
                test.Add(new Test() { Active = i < 5 });
            }
            FlowList.FlowItemsSource = test;
        }
    }
}
