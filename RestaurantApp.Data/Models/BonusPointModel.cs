using System;

namespace RestaurantApp.Data.Models
{
    public class BonusPointModel : BaseModel
    {
        public int PersonId { get; set; }
        public string Description { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActivated { get; set; }
    }
}