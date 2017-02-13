using System.Collections.Generic;
using RestaurantApp.Core.ViewModels;

namespace RestaurantApp.Core.Interfaces
{
    public interface IContentNavigationService
    {
        IDynamicContent MainPageModel { get; set; }
        List<IBaseContentView> StackNavigation { get; set; }
        IBaseContentView CurrentContentView { get; set; }
        void PushContentView(IBaseContentView contentView);
        void StepBackNavigation();
        void PushViewModel(BaseViewModel model);
        void PushViewModel<T>() where T : BaseViewModel;
    }
}