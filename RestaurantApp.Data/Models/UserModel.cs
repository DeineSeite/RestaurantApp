using System;
using Newtonsoft.Json;
using PropertyChanged;

namespace RestaurantApp.Data.Models
{
    public enum GenderType
    {
        Man = 1,
        Woman = 2
    }

    [ImplementPropertyChanged]
    public class UserModel : BaseModel
    {
        [JsonProperty(PropertyName = "nname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "vname")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Login
        {
            get
            {
                var login = FirstName + LastName;
                if (login.Length > 5)
                    return login.Substring(0, 5);
                return login;
            }
        }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "birthday")]
        public DateTime BirthDay { get; set; }

        [JsonProperty(PropertyName = "passwort")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "passwort2")]
        public string Password2 => Password;

        [JsonProperty(PropertyName = "mobil")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "geschlecht")]
        public GenderType Gender { get; set; }

        [JsonProperty(PropertyName = "facebookid")]
        public string FacebookId { get; set; }

        [JsonProperty(PropertyName = "twitterid")]
        public string TwitterId { get; set; }

        [JsonProperty(PropertyName = "googleplusId")]
        public string GoogleplusId { get; set; }

        public string RecommendBy { get; set; }

        public string AccessToken { get; set; }
    }
}