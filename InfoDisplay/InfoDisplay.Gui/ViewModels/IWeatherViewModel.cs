using System.Threading.Tasks;
using System.Windows.Input;
using InfoDisplay.WeatherService.Models;

namespace InfoDisplay.Gui.ViewModels
{

    public interface IWeatherViewModel
    {
        IWeatherResults Current { get; set; }

        IForecastResults Forecast { get; set; }

        bool Loading { get; set; }

        ICommand RefreshCommand { get; }

        Task GetWeatherAsync();
    }

}