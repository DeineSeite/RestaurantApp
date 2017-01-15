using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using PropertyChanged;
using RestaurantApp.Core.Localization;
using Xamarin.Forms;
using Page = Xamarin.Forms.Page;


namespace RestaurantApp.Core.PageModels
{
    [ImplementPropertyChanged]
  public class MainPageModel: MenuListPageModel
    {
     
        #region ctor
        public MainPageModel()
        {
            //Initialize menu
            var bonusPointPage = new GalleryPageModel() {Title = AppResources.Gallery};
            
            var infoPage = new MenuListPageModel
            {
                Title = AppResources.Info,
                MenuItemsList = new List<BasePageModel>()
                {
                    new AccountPageModel() {Title = AppResources.OpenHours},
                    new AccountPageModel() {Title = AppResources.Contacts},
                    new AccountPageModel() {Title = AppResources.Tables},
                    new AccountPageModel() {Title = AppResources.ParkPlace}
                }
            };
           
           var foodCardPage = new MenuListPageModel
           {
               Title = AppResources.FoodCard,
           MenuItemsList = new List<BasePageModel>()
               {
                   new AccountPageModel() {Title = "Test2"},
                   new AccountPageModel() {Title = "Test2"},
                   new AccountPageModel() {Title = "Test2"}
               }

           };
           MenuItemsList = new List<BasePageModel>
           {
              bonusPointPage,
              infoPage,
              foodCardPage,

           };
              

        }
#endregion

     
    }
}