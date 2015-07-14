using InfoDisplay.Gui.UserControls;
using InfoDisplay.Gui.ViewModels;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace InfoDisplay.Gui
{
    /// <summary>
    /// Main module.
    /// </summary>
    public class MainModule : IModule
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="container">Unity container.</param>
        /// <param name="regionManager">Region manager.</param>
        public MainModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            _container.RegisterType<Weather>();
            _container.RegisterType<IWeatherViewModel, WeatherViewModel>();
            _container.RegisterType<ISystemStatsViewModel, SystemStatsViewModel>();
            _container.RegisterType<InfoDisplayContainerViewModel>();

            _regionManager.RegisterViewWithRegion("MainRegion", typeof (InfoDisplayContainer));
        }

        #region Fields

        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        #endregion
    }
}
