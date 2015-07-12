namespace InfoDisplay.WeatherService.Models
{

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

    public interface IWeatherConditions
    {
        int Id { get; set; }

        string Main { get; set; }

        string Description { get; set; }

        string Icon { get; set; }

        WeatherCondition Condition { get; set; }
    }

}