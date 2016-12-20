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
  public class MainPageModel: BasePageModel
    {
        #region Public properties
        public Dictionary<Type, string> MenuItemsList { get; set; }
        public KeyValuePair<Type, string> SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                PushPageCommand.Execute(value);
            }
        }

        #endregion

        #region ctor
        public MainPageModel()
        {
            //Initialize menu
            MenuItemsList = new Dictionary<Type, string>
            {
                {typeof (BonusPointPageModel), AppResources.BonusPoints},
                {typeof (InfoPageModel), AppResources.Info},
                {typeof (FoodCardPageModel), AppResources.FoodCard},
                {typeof (ContactPageModel), AppResources.Contacts},
                {typeof (AccountPageModel), AppResources.Account}
            };

        }
#endregion

        #region Commands
         Command<KeyValuePair<Type, string>> PushPageCommand
        {
            get
            {
                return new Command<KeyValuePair<Type, string>>(async (page) =>
                {
                    var contentPage = FreshPageModelResolver.ResolvePageModel(page.Key, null);
                    contentPage.Title = page.Value;
                    await CurrentPage.Navigation.PushAsync(contentPage);
                });
            }
        }
        #endregion

        #region Private members

        KeyValuePair<Type, string> _selectedItem;

        #endregion
    }
}