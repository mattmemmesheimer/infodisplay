using InfoDisplay.WeatherService.Models;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    /// <summary>
    /// Concrete implementation of <see cref="IForecastTemperature"/> for Open Weather Map service.
    /// </summary>
    public class ForecastTemperature : IForecastTemperature
    {
        #region Properties

        /// <see cref="IForecastTemperature.Day"/>
        [JsonProperty(PropertyName = "day")]
        public double Day { get; set; }

        /// <see cref="IForecastTemperature.Min"/>
        [JsonProperty(PropertyName = "min")]
        public double Min { get; set; }

        /// <see cref="IForecastTemperature.Max"/>
        [JsonProperty(PropertyName = "max")]
        public double Max { get; set; }

        /// <see cref="IForecastTemperature.Night"/>
        [JsonProperty(PropertyName = "night")]
        public double Night { get; set; }

        /// <see cref="IForecastTemperature.Evening"/>
        [JsonProperty(PropertyName = "eve")]
        public double Evening { get; set; }

        /// <see cref="IForecastTemperature.Morning"/>
        [JsonProperty(PropertyName = "morn")]
        public double Morning { get; set; }

        #endregion
    }
}
