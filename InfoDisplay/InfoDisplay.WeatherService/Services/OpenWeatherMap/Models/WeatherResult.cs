using System;
using InfoDisplay.Common.Util.Json;
using InfoDisplay.WeatherService.Models;
using Microsoft.Practices.Prism.Mvvm;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    /// <summary>
    /// Abstract class defining weather result sets.
    /// </summary>
    public abstract class WeatherResult : BindableBase, IWeatherResult
    {
        #region Properties

        /// <see cref="IWeatherResult.Conditions"/>
        [JsonProperty(PropertyName = "weather")]
        [JsonConverter(typeof(ConcreteTypeConverter<WeatherConditions[]>))]
        public IWeatherConditions[] Conditions
        {
            get { return _conditions; }
            set { SetProperty(ref _conditions, value); }
        }

        /// <see cref="IWeatherResult.Date"/>
        [JsonProperty(PropertyName = "dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        #endregion

        #region Fields

        private IWeatherConditions[] _conditions;
        private DateTime _date;

        #endregion
    }
}
