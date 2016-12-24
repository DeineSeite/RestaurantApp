using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using Xamarin.Forms;

namespace RestaurantApp.Core.PageModels
{
 public class MenuListPageModel:BasePageModel
    {
        #region ctor

     public MenuListPageModel()
     {
            MenuItemsList=new List<BasePageModel>();
     }
        #endregion

        #region Public properties
        /// <summary>
        /// 
        /// </summary>
        public List<BasePageModel> MenuItemsList { get; set; }
        public BasePageModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                PushPageCommand.Execute(value);
            }
        }

        #endregion

        #region Commands
        Command<BasePageModel> PushPageCommand
        {
            get
            {
                return new Command<BasePageModel>(async (page) =>
                {
                    var contentPage = FreshPageModelResolver.ResolvePageModel(page.GetType(),null,page);
                    await CurrentPage.Navigation.PushAsync(contentPage);
                });
            }
        }
        #endregion

        #region Public methods
      /// <summary>
      /// Send parameter into PushPage
      /// </summary>
      /// <param name="parameter"></param>
     public void SetParameter(object parameter)
     {
         this._parameter = parameter;
     }
#endregion

        #region Private members
        BasePageModel _selectedItem;
        object _parameter;
     #endregion
    }
}
