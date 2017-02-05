using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.ViewModels;

namespace RestaurantApp.Core.Interfaces
{
    public interface IDynamicContent
    {
        IBaseContentView MainContentView { get; set; }
        bool IsBusy { get; set; }
    }
}
