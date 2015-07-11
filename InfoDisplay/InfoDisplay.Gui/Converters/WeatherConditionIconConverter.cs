using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using InfoDisplay.WeatherService.Models;

namespace InfoDisplay.Gui.Converters
{

    public class WeatherConditionIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var condition = (WeatherCondition) value;
            var resources = Application.Current.Resources;
            string key = string.Empty;
            switch (condition)
            {
                case WeatherCondition.DayClear:
                    key = "WeatherDayClearIcon";
                    break;
                case WeatherCondition.NightClear:
                    key = "WeatherNightClearIcon";
                    break;
                case WeatherCondition.DayCloudy:
                    key = "WeatherDayCloudyIcon";
                    break;
            }
            if (key == string.Empty)
            {
                return Binding.DoNothing;
            }
            return (ControlTemplate) resources[key];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}