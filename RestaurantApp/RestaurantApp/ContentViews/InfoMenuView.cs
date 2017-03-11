using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.ViewModels;
using RestaurantApp.Data.Models;
using RestaurantApp.Localizations;

namespace RestaurantApp.ContentViews
{
    public class InfoMenuView : MenuView
    {
        public InfoMenuView()
        {
            var items = new List<MenuItem>()
            {
                new MenuItem(typeof(OpenHoursView), AppResources.OpenHours),
                new MenuItem(typeof(TableOrderView), AppResources.Tables),
                new MenuItem(typeof(GalleryView), AppResources.Gallery),
            };
            SetMenuItems(items);
        }
    }
}
