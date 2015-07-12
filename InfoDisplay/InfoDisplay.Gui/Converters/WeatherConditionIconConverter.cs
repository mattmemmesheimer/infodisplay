using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using InfoDisplay.WeatherService.Models;

namespace InfoDisplay.Gui.Converters
{
    /// <summary>
    /// Converts between a <see cref="WeatherCondition"/> and a 
    /// <see cref="ControlTemplate"/> weather icon.
    /// </summary>
    public class WeatherConditionIconConverter : IValueConverter
    {
        /// <see cref="IValueConverter.Convert"/>
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
                case WeatherCondition.DayFewClouds:
                    key = "WeatherDayFewCloudsIcon";
                    break;
                case WeatherCondition.NightFewClouds:
                    key = "WeatherNightFewCloudsIcon";
                    break;
                case WeatherCondition.ScatteredClouds:
                    key = "WeatherScatteredCloudsIcon";
                    break;
                case WeatherCondition.BrokenClouds:
                    key = "WeatherBrokenCloudsIcon";
                    break;
                case WeatherCondition.Rain:
                    key = "WeatherRainIcon";
                    break;
                case WeatherCondition.Thunderstorm:
                    key = "WeatherThunderstormIcon";
                    break;
                case WeatherCondition.Snow:
                    key = "WeatherSnowIcon";
                    break;
            }
            if (key == string.Empty || !resources.Contains(key))
            {
                return Binding.DoNothing;
            }
            return (ControlTemplate) resources[key];
        }

        /// <see cref="IValueConverter.ConvertBack"/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

}