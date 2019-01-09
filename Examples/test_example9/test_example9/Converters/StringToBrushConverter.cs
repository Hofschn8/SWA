using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace test_example9.Converters
{
    class StringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;
            if (val.Equals("ready"))
            {
                return new SolidColorBrush(Colors.Green);
            }
            else if (val.Equals("processing"))
            {
                return new SolidColorBrush(Colors.Red);
            } 
            else if (val.Equals("waiting"))
            {
                return new SolidColorBrush(Colors.Orange);
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
