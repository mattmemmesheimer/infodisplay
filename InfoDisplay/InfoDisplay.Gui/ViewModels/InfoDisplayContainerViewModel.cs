using InfoDisplay.Gui.UserControls;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.Gui.ViewModels
{
    /// <summary>
    /// View model for the <see cref="InfoDisplayContainer"/>.
    /// </summary>
    public class InfoDisplayContainerViewModel : BindableBase
    {
        #region Properties

        /// <summary>
        /// View model for the <see cref="Weather"/> view.
        /// </summary>
        public IWeatherViewModel WeatherViewModel { get; set; }

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="weatherViewModel">Weather view model.</param>
        public InfoDisplayContainerViewModel(IWeatherViewModel weatherViewModel)
        {
            WeatherViewModel = weatherViewModel;
        }
    }
}
