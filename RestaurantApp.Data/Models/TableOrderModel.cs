﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data.Models
{
  public  class TableOrderModel:BaseModel
    {
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PersonCount { get; set; }
        public bool Smoker { get; set; }
        public int Hash => GetHashCode();

        public TableOrderModel()
        {
            Smoker = false;
            ReservationDate=DateTime.Now;
        }

    }
}
