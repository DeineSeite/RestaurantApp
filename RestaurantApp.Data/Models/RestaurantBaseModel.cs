using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data.Models
{
  public abstract class RestaurantBaseModel:BaseModel
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
    }
}
