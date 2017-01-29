using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestaurantApp.Data.Models
{
    public class RestaurantModel:BaseModel
    {
        public string DataPartitionId { get; set; }

        string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                // DisplayName is dependent on FirstName
                OnPropertyChanged(nameof(DisplayName));
                // DisplayLastNameFirst is dependent on FirstName
                OnPropertyChanged(nameof(DisplayLastNameFirst));
            }
        }

        string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                // DisplayName is dependent on LastName
                OnPropertyChanged(nameof(DisplayName));
                // DisplayLastNameFirst is dependent on LastName
                OnPropertyChanged(nameof(DisplayLastNameFirst));
            }
        }

        string _Company;
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        string _JobTitle;
        public string JobTitle
        {
            get { return _JobTitle; }
            set { _JobTitle = value; }
        }

        string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email=value; }
        }

        string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        string _Street;
        public string Street
        {
            get { return _Street; }
            set
            {
                _Street = value;
                // AddressString is dependent on Street
                OnPropertyChanged(nameof(AddressString));
            }
        }

        string _City;
        public string City
        {
            get { return _City; }
            set
            {
                 _City=value;
                // AddressString is dependent on City
                OnPropertyChanged(nameof(AddressString));
            }
        }

        string _PostalCode;
        public string PostalCode
        {
            get { return _PostalCode; }
            set
            {
                _PostalCode = value;
                // AddressString is dependent on PostalCode
                OnPropertyChanged(nameof(AddressString));
                // StatePostal is dependent on PostalCode
                OnPropertyChanged(nameof(StatePostal));
            }
        }


        string _State;
        public string State
        {
            get { return _State; }
            set
            {
               _State=value;
                // AddressString is dependent on State
                OnPropertyChanged(nameof(AddressString));
                // StatePostal is dependent on State
                OnPropertyChanged(nameof(StatePostal));
            }
        }

        string _PhotoUrl;
        public string PhotoUrl
        {
            get { return _PhotoUrl; }
            set
            {
                _PhotoUrl = value;
                // SmallPhotoUrl is dependent on PhotoUrl
                OnPropertyChanged(nameof(SmallPhotoUrl));
            }
        }

        public string SmallPhotoUrl => PhotoUrl;

        [JsonIgnore]
        public string AddressString => string.Format(
            "{0} {1} {2} {3}",
            Street,
            !string.IsNullOrWhiteSpace(City) ? City + "," : "",
            State,
            PostalCode);

        [JsonIgnore]
        public string DisplayName => ToString();

        [JsonIgnore]
        public string DisplayLastNameFirst => $"{LastName}, {FirstName}";

        [JsonIgnore]
        public string StatePostal => State + " " + PostalCode;

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
    

