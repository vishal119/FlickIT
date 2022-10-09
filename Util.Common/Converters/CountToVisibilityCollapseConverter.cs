using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Util.Common.Converters
{
    public class CountToVisibilityCollapseConverter : ValueConverter
    {
        public static IValueConverter Instance { get; } = new CountToVisibilityCollapseConverter();

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int count) && count > 0)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }
    }
}
