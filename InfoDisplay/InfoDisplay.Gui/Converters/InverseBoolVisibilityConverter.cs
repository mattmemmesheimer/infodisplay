using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace InfoDisplay.Gui.Converters
{
    /// <summary>
    /// Converts between a <see cref="bool" /> and <see cref="Visibility" />, but inversely of
    /// <see cref="BooleanToVisibilityConverter"/>.
    /// </summary>
    public class InverseBoolVisibilityConverter : IValueConverter
    {
        /// <see cref="IValueConverter.Convert"/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = (bool)value;
            return visibility ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <see cref="IValueConverter.ConvertBack"/>
        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            var visibility = (Visibility)value;
            return (visibility == Visibility.Collapsed);
        }
    }
}
