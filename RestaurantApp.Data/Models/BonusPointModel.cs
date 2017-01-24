using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data.Models
{
    public class BonusPointModel : BaseModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Description { get; set; }
        public DateTime ActivationDate{ get; set; }
        public DateTime ExpireDate{ get; set; }
        public bool IsActivated { get; set; }
    }
}
