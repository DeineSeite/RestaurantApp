using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Java.Security;

namespace RestaurantApp.Core.Interfaces
{
    public interface IBasePage
    {
        string Title { get; set; }
        string SubTitle { get; set; }
    }
}
