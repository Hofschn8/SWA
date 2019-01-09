using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Example6.Converters
{
    public class IntToBrushConverter : IValueConverter
    {
        SolidColorBrush green = new SolidColorBrush(Colors.Green);
        SolidColorBrush yellow = new SolidColorBrush(Colors.Yellow);
        SolidColorBrush red = new SolidColorBrush(Colors.Red);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int tmp = (int)value;
            if (tmp <= 2) return green;
            else if (tmp > 3) return red;
            else return yellow;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
