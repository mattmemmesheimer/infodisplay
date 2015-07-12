using System.Threading.Tasks;
using System.Windows.Input;
using InfoDisplay.Gui.Command;
using InfoDisplay.WeatherService;
using InfoDisplay.WeatherService.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.Gui.ViewModels
{
    /// <summary>
    /// Concrete implementation of <see cref="IWeatherViewModel"/>.
    /// </summary>
    public class WeatherViewModel : BindableBase, IWeatherViewModel
    {
        #region Properties

        /// <see cref="IWeatherViewModel.Current" />
        public IWeatherResults Current
        {
            get { return _current; }
            set { SetProperty(ref _current, value); }
        }

        /// <see cref="IWeatherViewModel.Forecast" />
        public IForecastResults Forecast
        {
            get { return _forecast; }
            set { SetProperty(ref _forecast, value); }
        }

        /// <see cref="IWeatherViewModel.Loading" />
        public bool Loading
        {
            get { return _loading; }
            set { SetProperty(ref _loading, value); }
        }

        /// <see cref="IWeatherViewModel.RefreshCommand" />
        public ICommand RefreshCommand { get; private set; }

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="weatherService">Weather service to use.</param>
        public WeatherViewModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
            RefreshCommand = new AwaitableDelegateCommand(GetWeatherAsync);
        }

        /// <see cref="IWeatherViewModel.GetWeatherAsync" />
        public async Task GetWeatherAsync()
        {
            Loading = true;
            Current = await _weatherService.GetWeatherAsync();
            Forecast = await _weatherService.GetForecastAsync();
            Loading = false;
        }

        #region Fields

        private double _temperature;
        private IWeatherService _weatherService;
        private IWeatherResults _current;
        private IForecastResults _forecast;
        private bool _loading;

        #endregion
    }
}
