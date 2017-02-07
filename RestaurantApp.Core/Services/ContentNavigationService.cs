using System.Collections.Generic;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using Xamarin.Forms;

namespace RestaurantApp.Core.Services
{
    public class ContentNavigationService : IContentNavigationService
    {

        public ContentNavigationService()
        {
            MainPageModel = FreshIOC.Container.Resolve<IDynamicContent>();
            StackNavigation = new List<IBaseContentView>();
            _currentPosition = -1;
            _isStepBack = false;
        }

        #region Public properties

        public IDynamicContent MainPageModel { get; set; }
        public List<IBaseContentView> StackNavigation { get; set; }
        public IBaseContentView CurrentContentView { get; set; }

        #endregion


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
                //Close app if stack is empty
                INativeHelper nativeHelper = null;
                nativeHelper = DependencyService.Get<INativeHelper>();
                if (nativeHelper != null)
                    nativeHelper.CloseApp();
            }

        }


        private int _currentPosition;
        private bool _isStepBack;
        private IBaseContentView _rootView;
    }
}