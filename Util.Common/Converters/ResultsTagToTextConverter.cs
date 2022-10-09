using System;
using System.Globalization;
using System.Windows.Data;

namespace Util.Common.Converters
{
    public class ResultsTagToTextConverter : ValueConverter
    {
        public static IValueConverter Instance { get; } = new ResultsTagToTextConverter();

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                return $"Showing results for the search \"{value}\"";
            }
            return string.Empty;
        }
    }
}
