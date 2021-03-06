﻿using System;
using System.Collections.Generic;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using Xamarin.Forms;
using MenuItem = RestaurantApp.Data.Models.MenuItem;


namespace RestaurantApp.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        #region ctor

        public MenuViewModel()
        {
            MenuItemsList = new List<MenuItem>();
            PushContentCommand = new Command<MenuItem>(PushContent);
            _contentNavigationService = FreshIOC.Container.Resolve<IContentNavigationService>();
        }

        #endregion

        #region Commands

        public Command<MenuItem> PushContentCommand { get; set; }

        #endregion

        #region Public properties

        private readonly IContentNavigationService _contentNavigationService;

        /// <summary>
        /// </summary>
        public List<MenuItem> MenuItemsList { get; set; }

        #endregion

        #region Public/Private members

        /// <summary>
        ///     Send parameter into ContentView
        /// </summary>
        /// <param name="parameter"></param>
        public void SetParameter(object parameter)
        {
          throw new NotImplementedException();
        }

        private void PushContent(MenuItem view)
        {
            IBaseContentView contentView;
            if (!NavigationContentService.ViewsCache.ContainsKey(view.ViewType))
            {
                contentView = ContentViewModelResolver.ResolveViewModel(view.ViewType, view.Params);
                contentView.Title = view.Title;
            }
            else
            {
                contentView = NavigationContentService.ViewsCache[view.ViewType];
            }
            _contentNavigationService.PushContentView(contentView);
        }

        #endregion

        #region Private members

        private BaseViewModel _selectedItem;
        private object _parameter;

        #endregion
    }
}