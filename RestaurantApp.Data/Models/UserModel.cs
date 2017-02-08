using System;
using PropertyChanged;

namespace RestaurantApp.Data.Models
{
    [ImplementPropertyChanged]
    public class UserModel : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}