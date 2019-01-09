using Example2_Server.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Example2_Server.Converter
{
    public class UsernameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<User> tmp = (ObservableCollection<User>)value;
            ObservableCollection<string> neueListe = new ObservableCollection<string>();
            foreach (var item in tmp)
                {
                neueListe.Add(item.Name);
                }
            return neueListe;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
