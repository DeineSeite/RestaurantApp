using RestaurantApp.Data.Models;
using Xamarin.Forms;

namespace RestaurantApp.UserControls
{
    public class BonusPointDataTemplateSelector : DataTemplateSelector
    {
        private DataTemplate _bonusPointItemTemplate;
  

        public BonusPointDataTemplateSelector()
        {
        
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var bonusPointModel = item as BonusPointModel;
            var template = new BonusPointItemTemplate();
            if (bonusPointModel == null)
                return null;

            if (!bonusPointModel.IsActivated && bonusPointModel.IsLastInList)
            {
                template.IsScannItemActived = true;
            }


            // Retain instances!
            _bonusPointItemTemplate = new DataTemplate(() => template);
            return _bonusPointItemTemplate;
        }
    }
}