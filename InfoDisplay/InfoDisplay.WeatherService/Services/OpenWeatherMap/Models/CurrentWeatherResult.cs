using InfoDisplay.Common.Util.Json;
using InfoDisplay.WeatherService.Models;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    /// <summary>
    /// Concrete implementation of <see cref="ICurrentWeatherResult"/> for Open Weather Map service.
    /// </summary>
    public class CurrentWeatherResult : WeatherResult, ICurrentWeatherResult
    {
        #region Properties

        /// <see cref="ICurrentWeatherResult.Name"/>
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        /// <see cref="ICurrentWeatherResult.Main"/>
        [JsonProperty(PropertyName = "main")]
        [JsonConverter(typeof(ConcreteTypeConverter<Weather>))]
        public IWeather Main
        {
            get { return _main; }
            set { SetProperty(ref _main, value); }
        }

        #endregion

        #region Fields

        private string _name;
        private IWeather _main;

        #endregion
    }
}
