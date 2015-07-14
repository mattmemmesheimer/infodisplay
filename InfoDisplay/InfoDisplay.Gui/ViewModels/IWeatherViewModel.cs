using System.Threading.Tasks;
using System.Windows.Input;
using InfoDisplay.WeatherService.Models;

namespace InfoDisplay.Gui.ViewModels
{
    /// <summary>
    /// Defines an interface for the weather view model.
    /// </summary>
    public interface IWeatherViewModel
    {
        /// <summary>
        /// Current weather information.
        /// </summary>
        ICurrentWeatherResult Current { get; set; }

        /// <summary>
        /// Forecasted weather information.
        /// </summary>
        IForecastResults Forecast { get; set; }

        /// <summary>
        /// Whether or not weather information is loading.
        /// </summary>
        bool Loading { get; set; }

        /// <summary>
        /// Command to refresh weather information.
        /// </summary>
        ICommand RefreshCommand { get; }

        /// <summary>
        /// Asynchronously retrieves weather information.
        /// </summary>
        /// <returns>Void task.</returns>
        Task GetWeatherAsync();
    }

}