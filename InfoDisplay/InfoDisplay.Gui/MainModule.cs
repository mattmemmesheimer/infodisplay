using InfoDisplay.Gui.UserControls;
using InfoDisplay.Gui.ViewModels;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace InfoDisplay.Gui
{
    public class MainModule : IModule
    {
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
            _container.RegisterType<InfoDisplayContainerViewModel>();

            _regionManager.RegisterViewWithRegion("MainRegion", typeof (InfoDisplayContainer));
        }

        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
    }
}
