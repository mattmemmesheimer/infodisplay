using System;
using InfoDisplay.Common.Util;
using InfoDisplay.WeatherService.Models;
using Microsoft.Practices.Prism.Mvvm;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    public class WeatherResults : BindableBase, IWeatherResults
    {
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [JsonProperty(PropertyName = "weather")]
        [JsonConverter(typeof(ConcreteTypeConverter<WeatherConditions[]>))]
        public IWeatherConditions[] Conditions
        {
            get { return _conditions; }
            set { SetProperty(ref _conditions, value); }
        }

        [JsonProperty(PropertyName = "main")]
        [JsonConverter(typeof(ConcreteTypeConverter<Weather>))]
        public IWeather Current
        {
            get { return _current; }
            set { SetProperty(ref _current, value); }
        }

        [JsonProperty(PropertyName = "dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private string _name;
        private IWeatherConditions[] _conditions;
        private IWeather _current;
        private DateTime _date;
    }
}
