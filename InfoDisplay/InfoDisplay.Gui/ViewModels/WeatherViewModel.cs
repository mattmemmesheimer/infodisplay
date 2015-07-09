using System.Threading.Tasks;
using InfoDisplay.WeatherService;
using InfoDisplay.WeatherService.Models;
using InfoDisplay.WeatherService.Services.OpenWeatherMap.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.Gui.ViewModels
{
    public class WeatherViewModel : BindableBase, IWeatherViewModel
    {
        public IWeatherResults Results
        {
            get { return _results; }
            set { SetProperty(ref _results, value); }
        }

        public string Status
        {
            get
            {
                return _status;
            }
            set { SetProperty(ref _status, value); }
        }

        public WeatherViewModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
            Status = "Idle";
        }

        public async Task GetWeatherAsync()
        {
            Status = "Loading...";

            Results = await _weatherService.GetWeatherAsync();

            Status = "Idle";
        }

        private double _temperature;
        private IWeatherService _weatherService;
        private IWeatherResults _results;
        private string _status;
    }
}
