using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantApp.Converters
{
    public class StringCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            string param = System.Convert.ToString(parameter) ?? "UPPER";

            switch (param.ToUpper())
            {
                case "UPPER":
                    return ((string) value).ToUpper();
                case "LOWER":
                    return ((string) value).ToLower();
                default:
                    return ((string) value);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
