using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Core.ViewModels
{
  public  class GalleryViewModel:BaseViewModel
    {
        public String Url
        {
            get;
        } = "http://www.luckywok.at/galerie/40/gallery2";
    }
}
