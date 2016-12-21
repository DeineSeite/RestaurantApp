using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using Xamarin.Forms;

namespace RestaurantApp.Pages
{
 public class BasePage:FreshBaseContentPage
    {
       
     public BasePage()
     {
            NavigationPage.SetHasNavigationBar(this, false);//Hide navigation bar
            
     }
     
    }
}
