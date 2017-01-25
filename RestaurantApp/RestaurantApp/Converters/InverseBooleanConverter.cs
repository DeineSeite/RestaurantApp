using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantApp.Converters
{
   public class LastItemBooleanConverter : IValueConverter
   {
       
 
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (!(bool) value&&!App.IsLastItemAdded)
            {
                App.IsLastItemAdded = true;
                if (targetType != typeof(bool))
                    throw new InvalidOperationException("The target must be a boolean");

                return true;
            }
            return false;

        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
