using InfoDisplay.Common.Util;
using InfoDisplay.WeatherService.Models;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    public class ForecastResults : IForecastResults
    {
        [JsonProperty(PropertyName = "list")]
        [JsonConverter(typeof(ConcreteTypeConverter<WeatherResults[]>))]
        public IWeatherResults[] Days { get; set; }
    }
}
