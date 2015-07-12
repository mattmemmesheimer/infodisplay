using System.Threading.Tasks;
using InfoDisplay.WeatherService.Models;

namespace InfoDisplay.WeatherService
{
    /// <summary>
    /// Defines a weather service interface.
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Asynchronously retrieves the current weather information.
        /// </summary>
        /// <returns>The current weather information.</returns>
        Task<IWeatherResults> GetWeatherAsync();

        /// <summary>
        /// Asynchronously retrieves weather forecast information.
        /// </summary>
        /// <returns>Weather forecast information.</returns>
        Task<IForecastResults> GetForecastAsync();
    }

}