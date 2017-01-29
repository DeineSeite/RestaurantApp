using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using Xamarin.Forms;

namespace RestaurantApp.Core.PageModels
{
    public class MenuListPageModel : BasePageModel
    {
        #region ctor

        public MenuListPageModel()
        {
            MenuItemsList = new List<BasePageModel>();
            PushPageCommand = new Command<BasePageModel>(PushPage);
        }
        #endregion

        #region Public properties


        /// <summary>
        /// 
        /// </summary>
        public List<BasePageModel> MenuItemsList { get; set; }
        #endregion

        #region Commands
        public Command<BasePageModel> PushPageCommand { get; set; }
        #endregion

        #region Public/Private members
        /// <summary>
        /// Send parameter into PushPage
        /// </summary>
        /// <param name="parameter"></param>
        public void SetParameter(object parameter)
        {
            this._parameter = parameter;
        }

        private async void PushPage(BasePageModel page)
        {
            var contentPage = FreshPageModelResolver.ResolvePageModel(page.GetType(), null, page);
            await CurrentPage.Navigation.PushModalAsync(contentPage, false);
        }
        #endregion

        #region Private members
        BasePageModel _selectedItem;
        object _parameter;
        #endregion
    }
}
