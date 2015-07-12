using InfoDisplay.WeatherService.Models;
using Microsoft.Practices.Prism.Mvvm;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    /// <summary>
    /// Concrete implementation of <see cref="IWeather"/> for Open Weather Map service.
    /// </summary>
    public class Weather : BindableBase, IWeather
    {
        #region Properties

        /// <see cref="IWeather.Temperature"/>
        [JsonProperty(PropertyName = "temp")]
        public double Temperature
        {
            get { return _temperature; }
            set { SetProperty(ref _temperature, value); }
        }

        /// <see cref="IWeather.Humidity"/>
        [JsonProperty(PropertyName = "humidity")]
        public double Humidity
        {
            get { return _humidity; }
            set { SetProperty(ref _humidity, value); }
        }

        #endregion

        #region Fields

        private double _temperature;
        private double _humidity;

        #endregion
    }
}
