using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EApp.Converter
{
    public class BoolToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (bool)value;
            var par = (string[])parameter;
            //
            if (par == null && par.Length < 2)
                return null;
            return val ? par[0] : par[1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var par = (string[])parameter;

            return value.ToString() == par[0];
        }
    }
}
