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
            var bonusPointPage = new BonusPointPageModel() {Title = AppResources.BonusPoints,SubTitle = "Abend"};
            
            var infoPage = new MenuListPageModel
            {
                Title = AppResources.Info,
                MenuItemsList = new List<BasePageModel>()
                {
                    new AccountPageModel() {Title = AppResources.OpenHours},
                    new ContactPageModel() {Title = AppResources.Contacts},
                    new TblReservationPage() {Title = AppResources.Tables},
                    new AccountPageModel() {Title = AppResources.ParkPlace}
                }
            };

            var foodCardPage = new FoodCardPageModel() {Title=AppResources.FoodCard};
          
           var galeryPage= new GalleryPageModel() { Title = AppResources.Gallery};

            MenuItemsList = new List<BasePageModel>
           {
              bonusPointPage,
              infoPage,
              foodCardPage,
              galeryPage

           };
              

        }
#endregion

     
    }
}