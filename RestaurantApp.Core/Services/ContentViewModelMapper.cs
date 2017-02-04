using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.Interfaces;

namespace RestaurantApp.Core.Services
{
    public class ContentViewModelMapper : IContentViewModelMapper
    {
        public string GetViewTypeName(Type viewModelType)
        {
            return viewModelType.AssemblyQualifiedName
                 .Replace("ViewModel", "View");
        }
    }
}