using InfoDisplay.Common.Util.Json;
using InfoDisplay.WeatherService.Models;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    /// <summary>
    /// Concrete implementation of <see cref="IForecastResults"/> for Open Weather Map service.
    /// </summary>
    public class ForecastResults : IForecastResults
    {
        #region Properties

        /// <see cref="IForecastResults.Days"/>
        [JsonProperty(PropertyName = "list")]
        [JsonConverter(typeof(ConcreteTypeConverter<WeatherResults[]>))]
        public IWeatherResults[] Days { get; set; }

        #endregion
    }
}
