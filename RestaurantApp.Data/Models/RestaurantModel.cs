using Newtonsoft.Json;
using PropertyChanged;

namespace RestaurantApp.Data.Models
{
    [ImplementPropertyChanged]
    public class RestaurantModel : BaseModel
    {

        public string Company { get; set; }

        public string JobTitle { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string PhotoUrl { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public string SmallPhotoUrl => PhotoUrl;

        [JsonIgnore]
        public string AddressString =>
            $"{Street} {(!string.IsNullOrWhiteSpace(City) ? City + "," : "")} {State} {PostalCode}";

        [JsonIgnore]
        public string DisplayName => ToString();

   
        [JsonIgnore]
        public string StatePostal => State + " " + PostalCode;
    }
}