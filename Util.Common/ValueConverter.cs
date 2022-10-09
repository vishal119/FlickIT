using System;
using System.Globalization;
using System.Windows.Data;

namespace Util.Common
{
    public abstract class ValueConverter : IValueConverter
    {

        #region IValueConverter Members

        /// <summary>
        /// Abstract convert implementation.
        /// </summary>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Virtual convert back implementation.
        /// </summary>
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        #endregion
    }
}
