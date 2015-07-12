﻿using System;

namespace InfoDisplay.WeatherService.Models
{

    public interface IWeatherResults
    {
        string Name { get; set; }

        IWeatherConditions[] Conditions { get; set; }

        IWeather Main { get; set; }

        DateTime Date { get; set; }
    }

}