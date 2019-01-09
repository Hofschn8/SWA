using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Example7.Converters
{
    public class DoubleToBrushConverter : IValueConverter
    {
        SolidColorBrush green = new SolidColorBrush(Colors.Green);
        SolidColorBrush red = new SolidColorBrush(Colors.Red);
        SolidColorBrush orange = new SolidColorBrush(Colors.Orange);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double tmp = (double)value;
            if (tmp >= 5) return green;
            else if (tmp >= 3) return orange;
            else return red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
