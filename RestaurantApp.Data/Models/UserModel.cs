using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        [JsonProperty(PropertyName = "nname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "vname")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "uname")]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "birthday")]
        public DateTime BirthDay { get; set; }

        [JsonProperty(PropertyName = "pwd")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "mobil")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "gender")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GenderType Gender { get; set; }

        [JsonProperty(PropertyName = "facebookid")]
        public string FacebookId { get; set; }

        [JsonProperty(PropertyName = "twitterid")]
        public string TwitterId { get; set; }

        [JsonProperty(PropertyName = "googleplusId")]
        public string GoogleplusId { get; set; }
    }
}