using System;
using System.Collections.Generic;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using Xamarin.Forms;

namespace RestaurantApp.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        #region ctor

        public MenuViewModel()
        {
            MenuItemsList = new List<BaseContentView>();
            PushContentCommand = new Command<BaseContentView>(PushContent);
            _contentNavigationService = FreshIOC.Container.Resolve<IContentNavigationService>();
        }

        #endregion

        #region Commands

        public Command<BaseContentView> PushContentCommand { get; set; }

        #endregion

        #region Public properties

        private readonly IContentNavigationService _contentNavigationService;

        /// <summary>
        /// </summary>
        public List<BaseContentView> MenuItemsList { get; set; }

        #endregion

        #region Public/Private members

        /// <summary>
        ///     Send parameter into ContentView
        /// </summary>
        /// <param name="parameter"></param>
        public void SetParameter(object parameter)
        {
            new NotImplementedException();
        }

        private async void PushContent(BaseContentView view)
        {
          //  var viewContent = ContentViewModelResolver.ResolveViewModel((object) null, view);
           await _contentNavigationService.PushContentViewAsync(view);
        }

        #endregion

        #region Private members

        private BaseViewModel _selectedItem;
        private object _parameter;

        #endregion
    }
}