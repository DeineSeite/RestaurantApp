using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SQLite.Net.Attributes;

namespace RestaurantApp.Data.Models
{
    public enum BonusPointType
    {
        Dinner,
        Lunch
    }

    public class BonusPointModel : BaseModel
    {
        public int PointId { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public string Hash { get; set; }        
        public  BonusPointType Type { get; set; }
        public string Description { get; set; }
        public DateTime ActivationDate { get; set; }

        [JsonIgnore, Ignore]
        public bool IsActivated { get; set; }

        [JsonIgnore,Ignore]
        public bool IsLastInList { get; set; }
    }
}