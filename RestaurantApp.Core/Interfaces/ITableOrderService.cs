using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Interfaces
{
    public interface ITableOrderService
    {
        Task<TableOrderModel> MakeOrder(TableOrderModel order);
    }
}
