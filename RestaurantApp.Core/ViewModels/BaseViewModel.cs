﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using FreshMvvm;
using RestaurantApp.Core.Annotations;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Data.Access;

namespace RestaurantApp.Core.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public  object Params { get; set; }
        public IBaseContentView CurrentContentView { get; set; }
        public bool IsAuthenticated => !string.IsNullOrEmpty(Settings.AccessToken);

        protected IContentNavigationService NavigationContentService
            => FreshIOC.Container.Resolve<IContentNavigationService>();
        protected IRestaurantDataAccess DataAccess
         => FreshIOC.Container.Resolve<IRestaurantDataAccess>();
        protected IMainPageModel ParentPageModel => FreshIOC.Container.Resolve<IMainPageModel>();
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void Init(object data)
        {
            Params = data;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}