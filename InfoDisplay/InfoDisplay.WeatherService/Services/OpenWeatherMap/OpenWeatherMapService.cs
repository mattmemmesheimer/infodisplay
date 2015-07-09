using System.Threading.Tasks;
using InfoDisplay.Common.Network;
using InfoDisplay.WeatherService.Models;
using InfoDisplay.WeatherService.Services.OpenWeatherMap.Models;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap
{

    public class OpenWeatherMapService : IWeatherService
    {
        public OpenWeatherMapService(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public async Task<IWeatherResults> GetWeatherAsync()
        {
            string url =
                "http://api.openweathermap.org/data/2.5/weather?zip=78759,us&APPID=0cc104f74d8d39c55e7c3806fe844861&units=imperial";

            var json = await _networkService.GetStringAsync(url);

            return JsonConvert.DeserializeObject<WeatherResults>(json);
        }

        private readonly INetworkService _networkService;
    }

}