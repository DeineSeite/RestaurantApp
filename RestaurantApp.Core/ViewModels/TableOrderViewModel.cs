using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using RestaurantApp.Data.Models;
using Xamarin.Forms;

namespace RestaurantApp.Core.ViewModels
{
    [ImplementPropertyChanged]
    public class TableOrderViewModel : BaseViewModel
    {
        public TableOrderModel Order { get; set; }
        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                Order.ReservationDate= Order.ReservationDate.Add(value);
                _time = value;
            }
        }

        public Command MakeOrderCommand { get; set; }

        public TableOrderViewModel()
        {
            Order = new TableOrderModel();
            MakeOrderCommand=new Command(MakerOrder);

        }

        private void MakerOrder()
        {
            var orderService = FreshMvvm.FreshIOC.Container.Resolve<ITableOrderService>();
            Order.UserId = 1;
            orderService.MakeOrder(Order);
        }
    }
}
