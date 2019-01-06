using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Gui.Converters
{
    public class BoolToBrushConverter : IValueConverter
    {
        private static SolidColorBrush green = new SolidColorBrush(Colors.Green);
        private static SolidColorBrush red = new SolidColorBrush(Colors.Red);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool tmp = (bool)value;

            if (tmp) { return green; }
            else
            {
                return red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
