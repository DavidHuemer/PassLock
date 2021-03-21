using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PassLock.GUI.Converter
{
    public class UriImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uriStr = (string)value;
            if(uriStr == null)
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
