using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Models;
using RestaurantApp.Localizations;

namespace RestaurantApp.ContentViews
{
   public class BonusPointMenuView:MenuView
    {
        public BonusPointMenuView()
        {
            var items = new List<MenuItem>()
            {
                new MenuItem(typeof(BonusPointView), AppResources.Lunch, BonusPointType.Lunch),
                new MenuItem(typeof(BonusPointView), AppResources.Dinner, BonusPointType.Dinner)
              
            };
            SetMenuItems(items);
        }
    }
}
