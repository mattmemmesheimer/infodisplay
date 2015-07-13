using System.Windows;
using InfoDisplay.Common.Network;
using InfoDisplay.Gui;
using InfoDisplay.WeatherService;
using InfoDisplay.WeatherService.Models;
using InfoDisplay.WeatherService.Services.OpenWeatherMap;
using InfoDisplay.WeatherService.Services.OpenWeatherMap.Models;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace InfoDisplay.Shell
{
    /// <summary>
    /// Uninty boot strapper.
    /// </summary>
    public class Bootstrapper : UnityBootstrapper
    {
        /// <see cref="UnityBootstrapper.CreateShell" />
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<PrismAppShell>();
        }

        /// <see cref="UnityBootstrapper.InitializeModules" />
        protected override void InitializeModules()
        {
            base.InitializeModules();
            Application.Current.MainWindow = (PrismAppShell)Shell;
            Application.Current.MainWindow.Show();
        }

        /// <see cref="UnityBootstrapper.ConfigureContainer" />
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<INetworkService, HttpNetworkService>();
            Container.RegisterType<IWeatherService, OpenWeatherMapService>();

            Container.RegisterType<ICurrentWeatherResult, CurrentWeatherResult>();
        }

        /// <see cref="UnityBootstrapper.ConfigureModuleCatalog" />
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var catalog = (ModuleCatalog) ModuleCatalog;
            catalog.AddModule(typeof (MainModule));
        }
    }
}
