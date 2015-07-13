namespace InfoDisplay.WeatherService.Models
{
    /// <summary>
    /// Defines a forecast weather result set interface.
    /// </summary>
    public interface IForecastResult : IWeatherResult
    {
        /// <summary>
        /// Forecasted temperature.
        /// </summary>
        IForecastTemperature ForecastTemperature { get; set; }
    }

}