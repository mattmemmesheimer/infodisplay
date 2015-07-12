namespace InfoDisplay.WeatherService.Models
{
    /// <summary>
    /// Enumeration of supported weather conditions.
    /// </summary>
    public enum WeatherCondition
    {
        DayClear,
        NightClear,
        DayFewClouds,
        NightFewClouds,
        ScatteredClouds,
        BrokenClouds,
        Rain,
        Thunderstorm,
        Snow,
        Unknown
    };

    /// <summary>
    /// Defines a weather conditions interface.
    /// </summary>
    public interface IWeatherConditions
    {
        /// <summary>
        /// Condition ID.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        string Main { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Icon name.
        /// </summary>
        string Icon { get; set; }

        /// <summary>
        /// Condition.
        /// </summary>
        WeatherCondition Condition { get; set; }
    }

}