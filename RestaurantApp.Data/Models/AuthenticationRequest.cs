using Newtonsoft.Json;

namespace RestaurantApp.Data.Models
{
    public class AuthenticationRequest
    {
        [JsonProperty(PropertyName ="email")]
        public string UserEmail { get; set; }

        [JsonProperty(PropertyName = "passwort")]
        public string Password { get; set; }

    }

}