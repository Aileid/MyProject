using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyProject.Core
{
    public class DateTimeConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToString("dd.MM.yyyy");

            //throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = ((string)value).Split('-');
            DateTime dt;
            return DateTime.TryParse((string?)value, out dt)?DateTime.Parse((string)value):null;//new DateTime(int.Parse(s[2]), int.Parse(s[1]), int.Parse(s[0]));

            //throw new ArgumentException();
        }
    }
}
