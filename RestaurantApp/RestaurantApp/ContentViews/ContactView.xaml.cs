using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace RestaurantApp.ContentViews
{
    public partial class ContactView : BaseContentView
    {
        public ContactView()
        {
            InitializeComponent();
            ContactMap.InfoWindowClicked += ContactMap_InfoWindowClicked;
            ContactMap.PinClicked += ContactMap_PinClicked;
            var contactModel = BindingContext as ContactViewModel;
            var pin= new Pin()

            {

                Type = PinType.Place,

                Label = contactModel.Restaurant.Company,

                Address = contactModel.Restaurant.AddressString,

                Position =new Position(contactModel.Restaurant.Latitude, contactModel.Restaurant.Longitude),
               

                IsVisible = true

            };
           ContactMap.Pins.Add(pin);
            ContactMap.SelectedPin = pin;
    
           ContactMap.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMeters(5000)));
        }

        private void ContactMap_PinClicked(object sender, PinClickedEventArgs e)
        {
            var contactModel = BindingContext as ContactViewModel;
            contactModel.NavigateTo();
        }

        private void ContactMap_InfoWindowClicked(object sender, InfoWindowClickedEventArgs e)
        {
            var contactModel = BindingContext as ContactViewModel;
            contactModel.NavigateTo();
        }
    }
}
