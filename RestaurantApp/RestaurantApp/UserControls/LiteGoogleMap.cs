using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;


namespace RestaurantApp.UserControls
{
  public  class LiteGoogleMap:Map
    {
        public  event EventHandler<Pin> LiteMarkerClicked;
      

        public virtual void OnInfoWindowClicked(Pin e)
        {
            LiteMarkerClicked?.Invoke(this, e);
        }
    }
}
