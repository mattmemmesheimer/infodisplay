using System.Threading.Tasks;
using InfoDisplay.WeatherService.Models;

namespace InfoDisplay.WeatherService
{

    public interface IWeatherService
    {
        Task<WeatherResults> GetWeatherAsync();
    }

}