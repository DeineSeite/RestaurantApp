using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.ViewModels;
using RestaurantApp.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace RestaurantApp.ContentViews
{
    public partial class ContactView : BaseContentView
    {
        public ContactView()
        {
            InitializeComponent();
            Task.Run(() => { InitMap(); });
            var nav = FreshMvvm.FreshIOC.Container.Resolve<IContentNavigationService>();
            nav.AddViewToCache(this);
        }

        private void InitMap()
        {
            var contactMap = new Map();
            contactMap.MapClicked += ContactMap_MapClicked;
           // contactMap.LiteMarkerClicked += ContactMap_LiteMarkerClicked;
            var contactModel = BindingContext as ContactViewModel;
            var pin = new Pin()
            {

                Type = PinType.Place,
                Label = contactModel.Restaurant.Company,
                Address = contactModel.Restaurant.AddressString,
                Position = new Position(contactModel.Restaurant.Latitude, contactModel.Restaurant.Longitude),
                IsVisible = true
            };
            contactMap.Pins.Add(pin);
            contactMap.SelectedPin = pin;

            contactMap.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMeters(5000)));
                MapView.Content=contactMap;
            
            
        }

        private void ContactMap_MapClicked(object sender, MapClickedEventArgs e)
        {
            var contactModel = BindingContext as ContactViewModel;
            contactModel?.NavigateTo();
        }

        private void ContactMap_LiteMarkerClicked(object sender, Pin e)
        {
            var contactModel = BindingContext as ContactViewModel;
            contactModel?.NavigateTo();
        }
        
    }
}
