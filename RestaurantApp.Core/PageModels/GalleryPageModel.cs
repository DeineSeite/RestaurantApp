using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Core.PageModels
{
   public class GalleryPageModel:BasePageModel
    {
        public  string HtmlSource { get; set; }

       public GalleryPageModel()
       {
           Load();
        }

       private async void Load()
       {
            WebRequest request = HttpWebRequest.Create("http://www.luckywok.at/galerie/40/gallery2");
            WebResponse response = await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
            var html = new HtmlAgilityPack.HtmlDocument();
            html.Load(response.GetResponseStream());
        var removeNode=   html.DocumentNode.ChildNodes.Where(
               n => n.Attributes.Contains("class") && (n.Attributes["class"].Value.Contains("appremoved")|| n.Attributes["class"].Value.Contains("apphiden")));
           foreach (var node in removeNode)
           {
               html.DocumentNode.RemoveChild(node);
           }

            
            
       }
    }
}
