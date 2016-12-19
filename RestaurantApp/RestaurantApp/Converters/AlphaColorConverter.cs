using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantApp.Converters
{
    public class AlphaColorConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if (targetType == typeof (Color))
            {
                var color = (Color) value;
                
                double alpha = double.Parse(parameter.ToString());
                color.MultiplyAlpha(alpha);
                return color;

            }
            return new InvalidOperationException("Cannot convert type" + targetType.Name + "to Color");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
