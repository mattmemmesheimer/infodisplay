using InfoDisplay.Common.Util.Json;
using InfoDisplay.WeatherService.Models;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    /// <summary>
    /// Concrete implementation of <see cref="IForecastResult"/> for Open Weather Map service.
    /// </summary>
    public class ForecastResult : WeatherResult, IForecastResult
    {
        #region Properties

        /// <see cref="ICurrentWeatherResult.Main"/>
        [JsonProperty(PropertyName = "temp")]
        [JsonConverter(typeof(ConcreteTypeConverter<ForecastTemperature>))]
        public IForecastTemperature ForecastTemperature
        {
            get { return _forecastTemperature; }
            set { SetProperty(ref _forecastTemperature, value); }
        }

        #endregion

        #region Fields

        private IForecastTemperature _forecastTemperature;

        #endregion
    }
}
