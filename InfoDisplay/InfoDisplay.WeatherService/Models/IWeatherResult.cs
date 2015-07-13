using System;

namespace InfoDisplay.WeatherService.Models
{

    public interface IWeatherResult
    {
        /// <summary>
        /// Weather conditions.
        /// </summary>
        IWeatherConditions[] Conditions { get; set; }

        /// <summary>
        /// Time of the weather results.
        /// </summary>
        DateTime Date { get; set; } 
    }

}