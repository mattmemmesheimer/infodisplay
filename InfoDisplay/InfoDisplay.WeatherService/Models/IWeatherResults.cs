using System;

namespace InfoDisplay.WeatherService.Models
{
    /// <summary>
    /// Defines a weather result set interface.
    /// </summary>
    public interface IWeatherResults
    {
        /// <summary>
        /// City name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Weather conditions.
        /// </summary>
        IWeatherConditions[] Conditions { get; set; }

        /// <summary>
        /// Main weather information (temp, humidity, etc.).
        /// </summary>
        IWeather Main { get; set; }

        /// <summary>
        /// Time of the weather results.
        /// </summary>
        DateTime Date { get; set; }
    }

}