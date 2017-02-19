using System.Collections.Generic;
using RestaurantApp.Core.ViewModels;

namespace RestaurantApp.Core.Interfaces
{
    public interface IContentNavigationService
    {
      
        List<IBaseContentView> StackNavigation { get; set; }
        IBaseContentView CurrentContentView { get; set; }
        void PushContentView(IBaseContentView contentView);
        bool StepBackNavigation();
        void PushViewModel(BaseViewModel model);
        void PushViewModel<T>() where T : BaseViewModel;
        void CleanStackNavigation();
    }
}