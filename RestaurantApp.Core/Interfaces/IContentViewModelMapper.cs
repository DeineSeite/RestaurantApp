using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Core.Interfaces
{
   public interface IContentViewModelMapper
   {
       string GetViewTypeName(Type viewModelType);
   }
}
