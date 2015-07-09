using Microsoft.Practices.Prism.Mvvm;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Models
{
    public class WeatherResults : BindableBase
    {
        [JsonProperty(PropertyName = "main")]
        public Main Main
        {
            get { return _main; }
            set { SetProperty(ref _main, value); }
        }

        private Main _main;
        private Weather _weather;
    }

    public class Main : BindableBase
    {
        [JsonProperty(PropertyName = "temp")]
        public double Temperature
        {
            get { return _temp; }
            set { SetProperty(ref _temp, value); }
        }

        [JsonProperty(PropertyName = "humidity")]
        public double Humidity
        {
            get { return _humidity; }
            set { SetProperty(ref _humidity, value); }
        }

        [JsonProperty(PropertyName = "pressure")]
        public double Pressure
        {
            get { return _pressure; }
            set { SetProperty(ref _pressure, value); }
        }


        private double _temp;
        private double _humidity;
        private double _pressure;
    }
}
