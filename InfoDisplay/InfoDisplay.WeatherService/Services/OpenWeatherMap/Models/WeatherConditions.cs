using InfoDisplay.WeatherService.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    public class WeatherConditions : BindableBase, IWeatherConditions
    {
        public int Id { get; set; }

        public string Main
        {
            get { return _main; }
            set { SetProperty(ref _main, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private string _main;
        private string _description;
    }
}
