using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLToolkit.Forms.Controls;
using RestaurantApp.Core.PageModels;
using RestaurantApp.Data.Models;
using RestaurantApp.UserControls;
using Xamarin.Forms;


namespace RestaurantApp.UserControls
{
   public class BonusPointDataTemplateSelector: FlowTemplateSelector
   {
       
        public BonusPointDataTemplateSelector()
        {
            _isLastItemReplaced = false;
        }
       
       
       protected override DataTemplate OnSelectTemplate(object item, int columnIndex, BindableObject container)
       {
            var bonusPointModel = item as BonusPointModel;
            var template = new BonusPointItemTemplate();
            if (bonusPointModel == null)
                return null;

            if (!bonusPointModel.IsActivated && !_isLastItemReplaced)
            {
                template.IsScannItemActived = true;
                _isLastItemReplaced = true;
            }


            // Retain instances!
            this._bonusPointItemTemplate = new DataTemplate(() => template);
            return _bonusPointItemTemplate;
        }
        private DataTemplate _bonusPointItemTemplate;
        private bool _isLastItemReplaced;
    }
}
