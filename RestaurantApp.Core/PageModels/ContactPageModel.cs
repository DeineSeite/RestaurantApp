using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantApp.Core.PageModels
{
   public class ContactPageModel : BasePageModel
    {
        public Command NavigateToMap { get; set; } 
        public  string HtmlContent { get; set; }
        public  string MapUrl { get; set; }
       public ContactPageModel()
       {
           string fileName = "RestaurantApp.Core.contactInfo.html";
            var assembly = typeof(ContactPageModel).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(fileName);
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            HtmlContent = text;
           MapUrl =
               "https://maps.googleapis.com/maps/api/staticmap?center=Wagramer+Str.+189B,+1210+Wien&zoom=14&scale=2&size=400x450&maptype=roadmap&format=png&visual_refresh=true&markers=size:mid%7Ccolor:0xff0000%7Clabel:%7CWagramer+Str.+189B,+1210+Wien";
            NavigateToMap=new Command(NavigateTo);
       }

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
