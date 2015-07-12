using System.Threading.Tasks;
using InfoDisplay.Common.Network;
using InfoDisplay.WeatherService.Models;
using InfoDisplay.WeatherService.Services.OpenWeatherMap.Models;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap
{
    /// <summary>
    /// Concrete implementation of <see cref="IWeatherService"/> for the Open Weather Map service.
    /// </summary>
    /// <remarks>
    /// See http://openweathermap.org/api for the API documentation.
    /// </remarks>
    public class OpenWeatherMapService : IWeatherService
    {
        #region Constants 

        private const string ServiceBaseUrl = "http://api.openweathermap.org/data/2.5";
        private const string ServiceApiKey = "0cc104f74d8d39c55e7c3806fe844861";
        private const string ServiceUnits = "imperial";

        #endregion

        #region Enums

        private enum WeatherAction
        {
            Current,
            Forecast
        }

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="networkService">Network service to use for data retrieval.</param>
        public OpenWeatherMapService(INetworkService networkService)
        {
            _networkService = networkService;
        }

        /// <see cref="IWeatherService.GetWeatherAsync"/>
        public async Task<IWeatherResults> GetWeatherAsync()
        {
            var url = GetUrl(WeatherAction.Current, "78759");
            var json = await _networkService.GetStringAsync(url);
            return JsonConvert.DeserializeObject<WeatherResults>(json);
        }

        /// <see cref="IWeatherService.GetForecastAsync"/>
        public async Task<IForecastResults> GetForecastAsync()
        {
            var url = GetUrl(WeatherAction.Forecast, "78759");
            url += "&cnt=4";
            var json = await _networkService.GetStringAsync(url);
            return JsonConvert.DeserializeObject<ForecastResults>(json);
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
                    actionStr = "forecast/daily";
                    break;
            }
            return string.Format("{0}/{1}?APPID={2}&units={3}&zip={4}", ServiceBaseUrl, actionStr,
                ServiceApiKey, ServiceUnits, zip);
        }

        #region Fields

        private readonly INetworkService _networkService;

        #endregion
    }

}