using System;
using System.Globalization;
using System.Windows.Data;

namespace PassLock.GUI.Converter.VaultConverters
{
    public class FirstLetterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = value as string;
            if (s != null && s.Length > 0)
                return s.Substring(0, 1);
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
