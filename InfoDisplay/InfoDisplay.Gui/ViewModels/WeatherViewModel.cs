using System.Threading.Tasks;
using System.Windows.Input;
using InfoDisplay.Gui.Command;
using InfoDisplay.WeatherService;
using InfoDisplay.WeatherService.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.Gui.ViewModels
{
    public class WeatherViewModel : BindableBase, IWeatherViewModel
    {
        public IWeatherResults Current
        {
            get { return _current; }
            set { SetProperty(ref _current, value); }
        }

        public IForecastResults Forecast
        {
            get { return _forecast; }
            set { SetProperty(ref _forecast, value); }
        }

        public bool Loading
        {
            get { return _loading; }
            set { SetProperty(ref _loading, value); }
        }

        public ICommand RefreshCommand { get; private set; }

        public WeatherViewModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;

            RefreshCommand = new AwaitableDelegateCommand(GetWeatherAsync);
        }

        public async Task GetWeatherAsync()
        {
            Loading = true;
            Current = await _weatherService.GetWeatherAsync();
            Forecast = await _weatherService.GetForecastAsync();
            Loading = false;
        }

        private double _temperature;
        private IWeatherService _weatherService;
        private IWeatherResults _current;
        private IForecastResults _forecast;
        private bool _loading;
    }
}
