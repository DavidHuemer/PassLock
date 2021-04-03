using PassLock.GUI.Controls.Custom.Buttons;
using System;
using System.Globalization;
using System.Windows.Data;

namespace PassLock.GUI.Converter
{
    public class NavigationItemSelectedConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value[0] == null || value[1] == null)
                return false;

            var navButton = value[1] as NavigationButton;
            return value[0] == navButton.DataContext;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
