using System;
using System.Globalization;
using Xamarin.Forms;

namespace EApp.Converter
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            string[] par = (string[])parameter;
            return val ? Color.FromHex(par[0]) : Color.FromHex(par[1]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
