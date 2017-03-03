using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Behaviors;
using RestaurantApp.Core.ViewModels;
using RestaurantApp.Data.Models;
using RestaurantApp.UserControls;
using Xamarin.Forms;

namespace RestaurantApp.ContentViews
{
    public partial class BonusPointView : BaseContentView
    {
        public BonusPointView()
        {
            InitializeComponent();
        }

        public BonusPointView(BonusPointType type)
        {
            InitializeComponent();
#if DEBUG
            FakeButton.IsVisible = false;
#endif
            var viewModel =new BonusPointViewModel(type);
            BindingContext = viewModel;
           
        }
    }
}
