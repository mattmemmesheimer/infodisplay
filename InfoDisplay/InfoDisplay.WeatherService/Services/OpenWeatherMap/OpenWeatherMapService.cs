using System;
using System.Threading.Tasks;
using InfoDisplay.Common.Network;
using InfoDisplay.WeatherService.Models;
using InfoDisplay.WeatherService.Services.OpenWeatherMap.Models;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap
{

    public class OpenWeatherMapService : IWeatherService
    {
        private const string ServiceBaseUrl = "http://api.openweathermap.org/data/2.5";
        private const string ServiceApiKey = "0cc104f74d8d39c55e7c3806fe844861";
        private const string ServiceUnits = "imperial";

        private enum WeatherAction
        {
            Current,
            Forecast
        }

        private string ServiceUrl
        {
            get
            {
                return string.Format("{0}?APPID={1}&units={2}", ServiceBaseUrl, ServiceApiKey,
                    ServiceUnits);
            }
        }

        public OpenWeatherMapService(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public async Task<IWeatherResults> GetWeatherAsync()
        {
            var url = GetUrl(WeatherAction.Current, "65856");
            var json = await _networkService.GetStringAsync(url);
            return JsonConvert.DeserializeObject<WeatherResults>(json);
        }

        private string GetUrl(WeatherAction action, string zip)
        {
            string actionStr = string.Empty;
            switch (action)
            {
                case WeatherAction.Current:
                    actionStr = "weather";
                    break;
                case WeatherAction.Forecast:
                    actionStr = "forecast";
                    break;
            }
            return string.Format("{0}/{1}?APPID={2}&units={3}&zip={4}", ServiceBaseUrl, actionStr,
                ServiceApiKey, ServiceUnits, zip);
        }

        private readonly INetworkService _networkService;
    }

}