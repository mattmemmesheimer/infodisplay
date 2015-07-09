using System.Threading.Tasks;

namespace InfoDisplay.Gui.ViewModels
{

    public interface IWeatherViewModel
    {
        Task GetWeatherAsync();
    }

}