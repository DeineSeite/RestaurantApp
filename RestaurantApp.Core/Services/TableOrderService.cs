using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Services
{
   public class TableOrderService:BaseService
    {
        public Task<TableOrderModel> MakeOrder(TableOrderModel order)
        {
            var builder = new UriBuilder(Settings.AuthenticationEndpoint);
            builder.Path = $"api/Restaurant/Reservation/";
            var uri = builder.ToString();
            var orderModel = RequestProvider.PostAsync(uri, order);
            return orderModel;
        }
    }
}
