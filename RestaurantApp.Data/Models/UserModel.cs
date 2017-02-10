using System;
using PropertyChanged;

namespace RestaurantApp.Data.Models
{
    [ImplementPropertyChanged]
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }
    }
}