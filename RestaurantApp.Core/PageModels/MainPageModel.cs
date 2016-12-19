using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using PropertyChanged;
using Page = Xamarin.Forms.Page;


namespace RestaurantApp.Core.PageModels
{
    [ImplementPropertyChanged]
  public class MainPageModel: BasePageModel
    {
        public MainPageModel()
        {
            var page = FreshPageModelResolver.ResolvePageModel<BonusPointPageModel>();
          
            MenuItemsList =new List<Page>();
            MenuItemsList.Add(FreshPageModelResolver.ResolvePageModel<BonusPointPageModel>());
            MenuItemsList.Add(FreshPageModelResolver.ResolvePageModel<InfoPageModel>());
            MenuItemsList.Add(FreshPageModelResolver.ResolvePageModel<FoodCardPageModel>());
            MenuItemsList.Add(FreshPageModelResolver.ResolvePageModel<ContactPageModel>());
            MenuItemsList.Add(FreshPageModelResolver.ResolvePageModel<AccountPageModel>());
        }
#region Public properties
        public List<Page> MenuItemsList { get; set; }
        public  Page SelectedItem {
            get { return _selectedItem; }
            set
            {
                Task.Run(async () =>
                {
                    _selectedItem = value;
                    await CoreMethods.PushPageModel(value.GetType());
                });
              
                
            }
        }
        #endregion
        #region Private members

        Page _selectedItem;

        #endregion
    }
}
