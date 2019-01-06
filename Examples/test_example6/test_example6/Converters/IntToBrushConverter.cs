using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace test_example6.Converters
{
    public class IntToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush scb;
            int val = (int)value;
            if (val < 3)
            {
                scb = new SolidColorBrush(Colors.Green);
            }
            else if (val < 5)
            {
                scb = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                scb = new SolidColorBrush(Colors.Red);
            }
            return scb;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
