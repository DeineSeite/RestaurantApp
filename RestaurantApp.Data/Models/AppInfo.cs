using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data.Models
{
   public class AppInfo
    {
        public  string OS { get; set; }
        public  string OSVersion { get; set; }
        public  string Language { get; set; }
        public  string AppVersion { get; set; }
        public string UniqueId { get; set; }
    }
}
