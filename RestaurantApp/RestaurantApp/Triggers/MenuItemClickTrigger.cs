using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantApp.Triggers
{
  public  class MenuItemClickTrigger:TriggerAction<VisualElement>
    {
      protected override void Invoke(VisualElement sender)
      {

         var t = sender.GetType();
      }
    }
}
