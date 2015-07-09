using System.Collections.Generic;

namespace InfoDisplay.WeatherService.Models
{

    public interface IWeatherResults
    {
        string Name { get; set; }

        IWeatherConditions[] Conditions { get; set; }

        IWeather Current { get; set; }
    }

}