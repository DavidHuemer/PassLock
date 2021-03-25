using System;
using System.Windows;
using System.Windows.Data;

namespace PassLock.GUI.Converter
{
    public class BooleanToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //valueTrueVisibility = true: value(true) gives Visibility.Visible
            //valueTrueVisibility = false: value(true) gives Visibility.Collapsed
            bool valueTrueVisibility = true;
            if (parameter != null)
                valueTrueVisibility = bool.Parse((string)parameter);

            if ((bool)value)
            {
                if (valueTrueVisibility)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            else
            {
                if (valueTrueVisibility)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value is Visibility visibility && visibility == Visibility.Visible ? true : (object)false;
        }
    }
}
