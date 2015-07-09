using System.Windows;
using InfoDisplay.Common.Network;
using InfoDisplay.Gui;
using InfoDisplay.WeatherService;
using InfoDisplay.WeatherService.Services;
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
        }
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var catalog = (ModuleCatalog) ModuleCatalog;
            catalog.AddModule(typeof (MainModule));
        }
    }
}
