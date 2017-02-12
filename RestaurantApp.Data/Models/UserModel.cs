using System;
using PropertyChanged;

namespace RestaurantApp.Data.Models
{
    public enum GenderType
    {
        Man=1,
        Woman=2
    }
    [ImplementPropertyChanged]
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobil { get; set; }
        public GenderType Gender { get; set; }
        public DateTime BirthDay { get; set; }
    }
}