using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Core.Interfaces
{
    public interface IBaseContentView
    {
        string Title { get; set; }
        string SubTitle { get; set; }

        object BindingContext { get; set; }
    }
}
