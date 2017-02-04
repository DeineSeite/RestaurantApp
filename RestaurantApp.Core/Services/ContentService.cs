using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Views;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.ViewModels;

namespace RestaurantApp.Core.Services
{
   public class ContentNavigationService:IContentNavigationService
    {
        public  IDynamicContent CurrentPageModel { get; set; }

        public ContentNavigationService()
        {
            CurrentPageModel = FreshIOC.Container.Resolve<IDynamicContent>();
        }

        public async Task PushContentViewAsync(BaseContentView contentView)
        {
            await Task.Run(() => { 
            CurrentPageModel.MainContentView = contentView;
            });
        }

      
    }
}
