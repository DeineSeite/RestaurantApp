using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Services
{
   public class TableOrderService:BaseService,ITableOrderService
    {
        private readonly IRequestProvider _requestProvider;

        public TableOrderService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }
        public Task<TableOrderModel> MakeOrder(TableOrderModel order)
        {
            var builder = new UriBuilder(AuthenticationEndpoint);
            builder.Path = $"api/Restaurant/Reservation/";
            var uri = builder.ToString();
            var orderModel = _requestProvider.PostAsync(uri, order);
            return orderModel;
        }
    }
}
