using System.Collections.Generic;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.ViewModels;
using Xamarin.Forms;

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
            _currentPosition = -1;
            _isStepBack = false;
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
            var contentView = ContentViewModelResolver.ResolveViewModel((object)null, model);
            PushContentView(contentView);
        }

        public void PushViewModel<T>() where T : BaseViewModel
        {
            var contentView = ContentViewModelResolver.ResolveViewModel<T>();
            PushContentView(contentView);
        }

        public void StepBackNavigation()
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
            }
            else
            {
                CloseApp(); //Close app if stack is empty
            }
        }

        private void CloseApp()
        {
            INativeHelper nativeHelper = null;
            nativeHelper = DependencyService.Get<INativeHelper>();
            nativeHelper?.CloseApp();
        }

        #region Public properties

        public IDynamicContent MainPageModel { get; set; }
        public List<IBaseContentView> StackNavigation { get; set; }
        public IBaseContentView CurrentContentView { get; set; }

        #endregion
    }
}