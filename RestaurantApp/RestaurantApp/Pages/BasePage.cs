using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using Xamarin.Forms;

namespace RestaurantApp.Pages
{
    public class BasePage : FreshBaseContentPage, IBasePage
    {
        #region Public properties
        /// <summary>
        ///Addition Title for ContentPage, will be shown under main Title
        /// </summary>
        public string SubTitle { get; set; }



        #endregion

        #region ctor
        public BasePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);//Hide navigation bar

        }
        #endregion

        #region Public/Private members
        public virtual void ReloadListView()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
