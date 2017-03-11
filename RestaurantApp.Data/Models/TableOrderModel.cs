using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data.Models
{
  public  class TableOrderModel:RestaurantBaseModel
    {
       
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public string PersonCount { get; set; }
        public bool Smoker { get; set; }
        private Guid Hash => Guid.NewGuid();

        public TableOrderModel()
        {
           
            Smoker = false;
            ReservationDate=DateTime.Now;
        }

    }
}
