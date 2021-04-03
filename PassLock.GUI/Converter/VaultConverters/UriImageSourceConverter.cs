using System;
using System.Globalization;
using System.Windows.Data;

namespace PassLock.GUI.Converter.VaultConverters
{
    public class UriImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uriStr = (string)value;
            if (uriStr == null)
            {
                uriStr = "pack://application:,,,/PassLock.GUI;component/Resources/Icons/default_favicon.ico";
                uriStr = @"https://github.com/favicon.ico";
            }

            return uriStr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
