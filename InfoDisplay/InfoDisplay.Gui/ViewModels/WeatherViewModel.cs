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
        public IWeatherResults Results
        {
            get { return _results; }
            set { SetProperty(ref _results, value); }
        }

        public bool Loading
        {
            get
            {
                return _loading;
            }
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
            Results = await _weatherService.GetWeatherAsync();
            Loading = false;
        }

        private double _temperature;
        private IWeatherService _weatherService;
        private IWeatherResults _results;
        private bool _loading;
    }
}
