using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;

namespace InfoDisplay.Gui.ViewModels
{
    public class InfoDisplayContainerViewModel : BindableBase
    {
        public IWeatherViewModel WeatherViewModel { get; set; }

        public InfoDisplayContainerViewModel(IUnityContainer container, IWeatherViewModel weatherViewModel)
        {
            WeatherViewModel = weatherViewModel;
        }
    }
}
