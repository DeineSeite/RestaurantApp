using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;

namespace RestaurantApp.Services
{
    public class RestaurantAppModelMapper : IFreshPageModelMapper, IContentViewModelMapper
    {
        public string GetPageTypeName(Type pageModelType)
        {
            var s = pageModelType.AssemblyQualifiedName
                .Replace("RestaurantApp.Core", "RestaurantApp")
                .Replace("RestaurantApp.Core.PageModels", "RestaurantApp.Pages")
                .Replace("PageModel", "Page");
            return s;
            // .Replace("PageModel", "Page")
        }

        public string GetViewTypeName(Type viewModelType)
        {
            var s = viewModelType.AssemblyQualifiedName
                .Replace("RestaurantApp.Core.ViewModels", "RestaurantApp.ContentViews")
                .Replace("RestaurantApp.Core", "RestaurantApp")
                .Replace("ViewModel", "View");
            return s;
        }
    }
}