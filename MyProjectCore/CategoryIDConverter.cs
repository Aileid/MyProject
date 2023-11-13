using MyProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyProject.Core
{
    public class CategoryIDConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            uint? id = (uint?)values[0];
            IEnumerable<CategoryModel> statuses = (IEnumerable<CategoryModel>)values[1];

            return statuses.FirstOrDefault(x => x.IDcategory == id)?.Name; 
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {

            throw new NotImplementedException();

        }
    }
}
