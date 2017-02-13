using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLToolkit.Forms.Controls;
using RestaurantApp.Data.Models;
using RestaurantApp.UserControls;
using Xamarin.Forms;

namespace RestaurantApp.Behaviors
{
    public class BonusPointTemplateSelector : FlowTemplateSelector
    {
        private bool IsScanButtonVisible = false;

        protected override DataTemplate OnSelectTemplate(object item, int columnIndex, BindableObject container)
        {
            var model = (BonusPointModel)item;
            if (!model.IsActivated&&!IsScanButtonVisible)
            {
                IsScanButtonVisible = true;
                  var template = new BonusPointItemTemplate();
                template.ScannImageButton.IsVisible = true;
                return  new DataTemplate(()=>template);
            }
            else
            {
                return new DataTemplate(typeof(BonusPointItemTemplate));

            }

        }
    }
}
