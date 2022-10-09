using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Util.Common.Converters
{
   public class StringToBoolConverter : ValueConverter
    {
        public static IValueConverter Instance { get; } = new StringToBoolConverter();
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.ToString() != string.Empty)
            {
                return true;
            }
            return false;
        }
    }
}
