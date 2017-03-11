using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.ViewModels;
using RestaurantApp.Data.Models;
using RestaurantApp.UserControls;


namespace RestaurantApp.ContentViews
{
    public partial class MenuView: BaseContentView
    {
        public MenuView()
        {
            InitializeComponent();
       
        }

        public void SetMenuItems(List<MenuItem> items)
        {
            var menuView = new MenuView();
            var menu = new MenuViewModel();
            menu.MenuItemsList = items;
            menuView.BindingContext = menu;
            Content = menuView;
        }
       

    }
}
