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
            var bonusPointPage = new SubMenuListPageModel {Title = AppResources.BonusPoints};
            var infoPage = new SubMenuListPageModel
            {
                Title = AppResources.Info,
                MenuItemsList = new List<BasePageModel>()
                {
                    new AccountPageModel() {Title = "Test"},
                    new AccountPageModel() {Title = "Test"}
                }
            };
            var foodCardPage = new SubMenuListPageModel
            {
                Title = AppResources.FoodCard,
            MenuItemsList = new List<BasePageModel>()
                {
                    new AccountPageModel() {Title = "Test2"},
                    new AccountPageModel() {Title = "Test2"},
                    new AccountPageModel() {Title = "Test2"}
                }
            };
            var contactPage = new SubMenuListPageModel {Title = AppResources.Contacts};
            var accountPage = new AccountPageModel {Title = AppResources.Account};
            MenuItemsList = new List<BasePageModel>
            {
               bonusPointPage,
               infoPage,
               foodCardPage,
               contactPage,
               accountPage
            };


        }
#endregion

     
    }
}