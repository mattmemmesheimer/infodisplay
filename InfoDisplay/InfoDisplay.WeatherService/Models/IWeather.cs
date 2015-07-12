namespace InfoDisplay.WeatherService.Models
{
    /// <summary>
    /// Defines a main weather information interface.
    /// </summary>
    public interface IWeather
    {
        /// <summary>
        /// Temperature.
        /// </summary>
        double Temperature { get; set; }

        /// <summary>
        /// Humidity.
        /// </summary>
        double Humidity { get; set; }
    }

}