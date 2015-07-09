using System.Windows;
using InfoDisplay.Common.Network;
using InfoDisplay.Gui;
using InfoDisplay.WeatherService;
using InfoDisplay.WeatherService.Models;
using InfoDisplay.WeatherService.Services;
using InfoDisplay.WeatherService.Services.OpenWeatherMap;
using InfoDisplay.WeatherService.Services.OpenWeatherMap.Models;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace InfoDisplay.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<PrismAppShell>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            Application.Current.MainWindow = (PrismAppShell)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<INetworkService, HttpNetworkService>();
            Container.RegisterType<IWeatherService, OpenWeatherMapService>();

            Container.RegisterType<IWeatherResults, WeatherResults>();
        }
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var catalog = (ModuleCatalog) ModuleCatalog;
            catalog.AddModule(typeof (MainModule));
        }
    }
}
