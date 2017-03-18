using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using RestaurantApp.Droid.Renderers;
using RestaurantApp.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LiteGoogleMap), typeof(CustomMapRenderer))]
namespace RestaurantApp.Droid.Renderers
{
    public class CustomMapRenderer : MapRenderer, IOnMapReadyCallback
    {
        private List<Pin> customPins;
        private bool isDrawn;
        private GoogleMap map;

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            map.InfoWindowClick += Map_InfoWindowClick;
            map.MarkerClick += Map_MarkerClick;
            map.UiSettings.ZoomControlsEnabled = false;
            map.UiSettings.MapToolbarEnabled = true;
        }

        private void Map_MarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
        {
            OnMarkerClicked(e.Marker);
        }

        private void Map_InfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            OnMarkerClicked(e.Marker);
        }

        private void OnMarkerClicked(Marker e)
        {
            var formsMap = (LiteGoogleMap) Element;
            var pin = new Pin();
            pin.Label = e.Title;
            pin.Position = new Position(e.Position.Latitude, e.Position.Longitude);
            pin.Address = e.Snippet;
            formsMap.OnInfoWindowClicked(pin);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var formsMap = (LiteGoogleMap) e.NewElement;
                customPins = formsMap.Pins.ToList();
                ((MapView) Control).GetMapAsync(this);
            }
        }

        protected override Android.Views.View CreateNativeControl()
        {
            base.CreateNativeControl();
            var mapOptions = new GoogleMapOptions();
            mapOptions.InvokeLiteMode(true);
            var mapControl = new MapView(Context, mapOptions);
            return mapControl;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
            {
                map.Clear();

                foreach (var pin in customPins)
                {
                    var options = new MarkerOptions();
                    options.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
                    options.SetTitle(pin.Label);
                    options.SetSnippet(pin.Address);
                    var marker = map.AddMarker(options);
                    marker.ShowInfoWindow();
                }
                isDrawn = true;
            }
        }


        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            if (changed)
                isDrawn = false;
        }
    }
}