using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantApp.Data.Models
{
   public class ActionModel:BaseModel
    {
        public  string Title { get; set; }
        public  string Description { get; set; }
        public  DateTime Date { get; set; }
        public  string Image { get; set; }

      
    }
}
