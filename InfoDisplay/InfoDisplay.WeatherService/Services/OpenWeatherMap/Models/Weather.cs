using InfoDisplay.WeatherService.Models;
using Microsoft.Practices.Prism.Mvvm;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    public class Weather : BindableBase, IWeather
    {
        [JsonProperty(PropertyName = "temp")]
        public double Temperature
        {
            get { return _temperature; }
            set { SetProperty(ref _temperature, value); }
        }

        [JsonProperty(PropertyName = "humidity")]
        public double Humidity
        {
            get { return _humidity; }
            set { SetProperty(ref _humidity, value); }
        }

        private double _temperature;
        private double _humidity;
    }
}
