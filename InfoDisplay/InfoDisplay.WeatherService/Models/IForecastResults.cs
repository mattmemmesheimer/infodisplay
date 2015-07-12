namespace InfoDisplay.WeatherService.Models
{
    /// <summary>
    /// Defines a weather forecast interface.
    /// </summary>
    public interface IForecastResults
    {
        /// <summary>
        /// Days of the forecast.
        /// </summary>
        IWeatherResults[] Days { get; set; }
    }

}