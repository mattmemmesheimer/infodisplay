namespace InfoDisplay.WeatherService.Models
{

    public enum WeatherCondition
    {
        DayClear,
        NightClear,
        DayCloudy
    };

    public interface IWeatherConditions
    {
        int Id { get; set; }

        string Main { get; set; }

        string Description { get; set; }

        WeatherCondition Condition { get; set; }
    }

}