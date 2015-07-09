namespace InfoDisplay.WeatherService.Models
{

    public interface IWeatherConditions
    {
        int Id { get; set; }

        string Main { get; set; }

        string Description { get; set; }
    }

}