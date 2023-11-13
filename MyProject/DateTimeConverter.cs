using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyProject.Core
{
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateTimeConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)// && DateTime.TryParse(value)
            {
                return ((DateTime)value).ToString("dd.MM.yyyy");
            }
            else
            {
                return value;
            }
            

            //throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = ((string)value).Split('-');
            DateTime dt;
            DateTime.TryParse((string?)value, out dt);
            return  dt;
            
            //throw new ArgumentException();
        }
    }
}
