namespace InfoDisplay.WeatherService.Models
{
    /// <summary>
    /// Defines a current weather result set interface.
    /// </summary>
    public interface ICurrentWeatherResult : IWeatherResult
    {
        /// <summary>
        /// City name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Main weather information (temp, humidity, etc.).
        /// </summary>
        IWeather Main { get; set; }
    }

}