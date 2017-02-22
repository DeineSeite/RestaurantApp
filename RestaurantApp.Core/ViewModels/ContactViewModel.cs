using System;
using System.IO;
using System.Net;
using System.Reflection;
using RestaurantApp.Data.Models;
using Xamarin.Forms;

namespace RestaurantApp.Core.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
       public double WidthMap { get; set; }
       public double HeightMap { get; set; }
     

        public ContactViewModel()
        {
            Restaurant = new RestaurantModel();
            Restaurant.Phone = "01/256 89 80";
            Restaurant.Email = "lokal@luckywok.at";
            Restaurant.Street = "Wagramer Strasse 189b";
            Restaurant.PostalCode = "1210";
            Restaurant.City = "Wien";
            Restaurant.Company = "Grill Asia";
            MapUrl =
                @"https://maps.googleapis.com/maps/api/staticmap?center=Wagramer+Strasse+189b,+1210+Wien&zoom=13&scale=false&size=700x400&maptype=roadmap&format=png&visual_refresh=true&markers=size:mid%7Ccolor:0xff0000%7Clabel:1%7CWagramer+Strasse+189b,+1210+Wien";
            string fileName = "RestaurantApp.Core.contactInfo.html";
            var assembly = typeof(ContactViewModel).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(fileName);
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            HtmlContent = text;
            //MapUrl =
            //    "https://maps.googleapis.com/maps/api/staticmap?center=Wagramer+Str.+189B,+1210+Wien&zoom=14&scale=2&size=400x450&maptype=roadmap&format=png&visual_refresh=true&markers=size:mid%7Ccolor:0xff0000%7Clabel:%7CWagramer+Str.+189B,+1210+Wien";
            // NavigateToMap=new Command(NavigateTo);
        }

        public Command NavigateToMap { get; set; }
        public string HtmlContent { get; set; }
        public string MapUrl { get; set; }
        public RestaurantModel Restaurant { get; set; }

        private void NavigateTo()
        {
            var address = "Wagramer Str. 189B, 1210 Wien";

            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                    Device.OpenUri(
                        new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(address))));
                    break;
                case TargetPlatform.Android:
                    Device.OpenUri(
                        new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(address))));
                    break;
                case TargetPlatform.Windows:
                case TargetPlatform.WinPhone:
                    Device.OpenUri(
                        new Uri(string.Format("bingmaps:?where={0}", Uri.EscapeDataString(address))));
                    break;
            }
        }
    }
}