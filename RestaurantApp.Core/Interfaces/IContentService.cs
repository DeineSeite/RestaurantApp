using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
