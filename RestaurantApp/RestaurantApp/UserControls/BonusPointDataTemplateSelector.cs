using RestaurantApp.Data.Models;
using Xamarin.Forms;

namespace RestaurantApp.UserControls
{
    public class BonusPointDataTemplateSelector : DataTemplateSelector
    {
        private DataTemplate _bonusPointItemTemplate;
        private bool _isLastItemReplaced;

        public BonusPointDataTemplateSelector()
        {
            _isLastItemReplaced = false;
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
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
            _bonusPointItemTemplate = new DataTemplate(() => template);
            return _bonusPointItemTemplate;
        }
    }
}