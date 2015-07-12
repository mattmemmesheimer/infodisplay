using System;
using InfoDisplay.Common.Util;
using InfoDisplay.Common.Util.Json;
using InfoDisplay.WeatherService.Models;
using Microsoft.Practices.Prism.Mvvm;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    /// <summary>
    /// Concrete implementation of <see cref="IWeatherResults"/> for Open Weather Map service.
    /// </summary>
    public class WeatherResults : BindableBase, IWeatherResults
    {
        #region Properties

        /// <see cref="IWeatherResults.Name"/>
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        /// <see cref="IWeatherResults.Conditions"/>
        [JsonProperty(PropertyName = "weather")]
        [JsonConverter(typeof(ConcreteTypeConverter<WeatherConditions[]>))]
        public IWeatherConditions[] Conditions
        {
            get { return _conditions; }
            set { SetProperty(ref _conditions, value); }
        }

        /// <see cref="IWeatherResults.Main"/>
        [JsonProperty(PropertyName = "main")]
        [JsonConverter(typeof(ConcreteTypeConverter<Weather>))]
        public IWeather Main
        {
            get { return _main; }
            set { SetProperty(ref _main, value); }
        }

        /// <see cref="IWeatherResults.Date"/>
        [JsonProperty(PropertyName = "dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        #endregion

        #region Fields

        private string _name;
        private IWeatherConditions[] _conditions;
        private IWeather _main;
        private DateTime _date;

        #endregion
    }
}
