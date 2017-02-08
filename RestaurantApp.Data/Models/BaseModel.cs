using PropertyChanged;

namespace RestaurantApp.Data.Models
{
    [ImplementPropertyChanged]
    public abstract class BaseModel
    {
        public int Id { get; set; }
    }
}