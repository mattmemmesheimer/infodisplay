using InfoDisplay.WeatherService.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    public class WeatherConditions : BindableBase, IWeatherConditions
    {
        public int Id { get; set; }

        public string Main
        {
            get { return _main; }
            set { SetProperty(ref _main, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public WeatherCondition Condition
        {
            get { return _condition; }
            set { SetProperty(ref _condition, value); }
        }

        public string Icon
        {
            get { return _icon; }
            set
            {
                SetProperty(ref _icon, value);
                Condition = StringToWeatherCondition(value);
            }
        }

        /// <summary>
        /// Based on the condition codes described in the OpenWeatherMap API documentation:
        /// http://openweathermap.org/weather-conditions
        /// </summary>
        /// <param name="conditionStr">Condition string.</param>
        /// <returns>Weather condition.</returns>
        private WeatherCondition StringToWeatherCondition(string conditionStr)
        {
            var condition = WeatherCondition.Unknown;
            switch (conditionStr)
            {
                case "01d":
                    condition =  WeatherCondition.DayClear;
                    break;
                case "01n":
                    condition = WeatherCondition.NightClear;
                    break;
                case "02d":
                    condition = WeatherCondition.DayFewClouds;
                    break;
                case "02n":
                    condition = WeatherCondition.NightFewClouds;
                    break;
                case "03d":
                case "03n":
                    condition = WeatherCondition.ScatteredClouds;
                    break;
                case "04d":
                case "04n":
                    condition = WeatherCondition.BrokenClouds;
                    break;
                case "09d":
                case "09n":
                case "10d":
                case "10n":
                    condition = WeatherCondition.Rain;
                    break;
                case "11d":
                case "11n":
                    condition = WeatherCondition.Thunderstorm;
                    break;
                case "13d":
                case "13n":
                    condition = WeatherCondition.Snow;
                    break;
            }
            return condition;
        }

        private string _main;
        private string _description;
        private string _icon;
        private WeatherCondition _condition;
    }
}
