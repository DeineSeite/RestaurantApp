using Newtonsoft.Json;
using PropertyChanged;
using SQLite.Net.Attributes;

namespace RestaurantApp.Data.Models
{
    [ImplementPropertyChanged]
    public class BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}