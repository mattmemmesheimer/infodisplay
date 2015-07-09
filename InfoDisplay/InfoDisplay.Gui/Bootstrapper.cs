using System.Windows;
using InfoDisplay.Common.Network;
using InfoDisplay.Gui.UserControls;
using InfoDisplay.Gui.ViewModels;
using InfoDisplay.WeatherService;
using InfoDisplay.WeatherService.Services;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
namespace InfoDisplay.Gui
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<PrismAppShell>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            Application.Current.MainWindow = (PrismAppShell) Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<INetworkService, HttpNetworkService>();
            Container.RegisterType<IWeatherService, OpenWeatherMapService>();

            Container.RegisterType<IWeatherViewModel, WeatherViewModel>();
        }
    }
}
