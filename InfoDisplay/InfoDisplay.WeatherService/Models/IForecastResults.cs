namespace InfoDisplay.WeatherService.Models
{

    public interface IForecastResults
    {
        IWeatherResults[] Days { get; set; }
    }

}