using System;
using System.Collections.Generic;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.ViewModels;

namespace RestaurantApp.Core.Services
{
    public class ContentNavigationService : IContentNavigationService
    {
        private int _currentPosition;
        private bool _isStepBack;
        private IBaseContentView _rootView;

        public ContentNavigationService()
        {
            MainPageModel = FreshIOC.Container.Resolve<IMainPageModel>();
            StackNavigation = new List<IBaseContentView>();
            ViewsCache = new Dictionary<Type, IBaseContentView>();
            _currentPosition = -1;
            _isStepBack = false;
        }

        public Dictionary<Type, IBaseContentView> ViewsCache { get; set; }

        public void AddViewToCache(IBaseContentView contentView)
        {
            ViewsCache.Add(contentView.GetType(), contentView);
        }

        public void PushContentView(IBaseContentView contentView)
        {
            MainPageModel.MainContentView = contentView;
            CurrentContentView = contentView;
            StackNavigation.Add(contentView);
            if (_rootView == null) _rootView = contentView;
            if (!_isStepBack) _currentPosition++;
            _isStepBack = false;

            //Reset AcitvityIndicator state
            MainPageModel.IsBusy = false;
        }

        public void PushViewModel(BaseViewModel model)
        {
            var contentView = ContentViewModelResolver.ResolveViewModel((object) null, model);
            PushContentView(contentView);
        }

        public void PushViewModel<T>() where T : BaseViewModel
        {
            var contentView = ContentViewModelResolver.ResolveViewModel<T>();
            PushContentView(contentView);
        }

        public bool StepBackNavigation()
        {
            _isStepBack = true;
            if (StackNavigation.Count > 0 && _currentPosition > 0)
            {
                _currentPosition--;
                if (_currentPosition == 0)
                {
                    StackNavigation.Clear();
                    PushContentView(_rootView);
                }
                else
                {
                    PushContentView(StackNavigation[_currentPosition]);
                }
                return true;
            }
            return false; //Go App to sleep if stack is empty
        }

        public void CleanStackNavigation()
        {
            try
            {
                StackNavigation.RemoveAt(1);
            }
            catch (Exception e)
            {
                AppDebugger.WriteLine("Cannot clean StackNavigation " + e.Message);
            }
        }

        #region Public properties

        public IMainPageModel MainPageModel { get; set; }
        public List<IBaseContentView> StackNavigation { get; set; }
        public IBaseContentView CurrentContentView { get; set; }

        #endregion
    }
}