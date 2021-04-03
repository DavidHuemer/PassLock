using System;
using System.Globalization;
using System.Windows.Data;

namespace PassLock.GUI.Converter.VaultConverters
{
    public class SearchTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"Search in {value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
