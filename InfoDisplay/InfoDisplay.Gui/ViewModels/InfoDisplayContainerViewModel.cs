using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;

namespace InfoDisplay.Gui.ViewModels
{
    /// <summary>
    /// View model for the <see cref="InfoDisplayContainer"/>.
    /// </summary>
    public class InfoDisplayContainerViewModel : BindableBase
    {
        #region Properties

        /// <summary>
        /// View model for a weather view.
        /// </summary>
        public IWeatherViewModel WeatherViewModel { get; set; }

        /// <summary>
        /// View model for a system stats view.
        /// </summary>
        public ISystemStatsViewModel SystemStatsViewModel { get; set; }

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="container">Unity container.</param>
        public InfoDisplayContainerViewModel(IUnityContainer container)
        {
            WeatherViewModel = container.Resolve<IWeatherViewModel>();
            SystemStatsViewModel = container.Resolve<ISystemStatsViewModel>();
        }
    }
}
