namespace InfoDisplay.WeatherService.Models
{

    public interface IWeather
    {
        double Temperature { get; set; }

        double Humidity { get; set; }
    }

}