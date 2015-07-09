using System.Threading.Tasks;
using InfoDisplay.WeatherService;
using InfoDisplay.WeatherService.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.Gui.ViewModels
{
    public class WeatherViewModel : BindableBase, IWeatherViewModel
    {
        public WeatherResults Results
        {
            get { return _results; }
            set { SetProperty(ref _results, value); }
        }

        public WeatherViewModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task GetWeatherAsync()
        {
            Results = await _weatherService.GetWeatherAsync();
        }

        private double _temperature;
        private IWeatherService _weatherService;
        private WeatherResults _results;
    }
}
