using System.Windows;
using InfoDisplay.Gui.ViewModels;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace InfoDisplay.Gui.UserControls
{
    /// <summary>
    /// Interaction logic for Weather.xaml
    /// </summary>
    public partial class Weather
    {

        public Weather()
        {
            InitializeComponent();



            _container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            _viewModel = _container.Resolve<IWeatherViewModel>();

            DataContext = _viewModel;

            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            await _viewModel.GetWeatherAsync();
        }

        private readonly IWeatherViewModel _viewModel;
        private readonly IUnityContainer _container;
    }
}
