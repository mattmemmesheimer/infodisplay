namespace InfoDisplay.WeatherService.Models
{
    /// <summary>
    /// Defines a forecasted temperature interface.
    /// </summary>
    public interface IForecastTemperature
    {
        /// <summary>
        /// Temperature during the day.
        /// </summary>
        double Day { get; set; }

        /// <summary>
        /// Minimum temperature throughout the day.
        /// </summary>
        double Min { get; set; }

        /// <summary>
        /// Maximum temperature throughout the day.
        /// </summary>
        double Max { get; set; }

        /// <summary>
        /// Temperature at night.
        /// </summary>
        double Night { get; set; }

        /// <summary>
        /// Temperature during the evening.
        /// </summary>
        double Evening { get; set; }

        /// <summary>
        /// Temperature in the morning.
        /// </summary>
        double Morning { get; set; }
    }

}