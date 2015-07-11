using System;
using System.Windows;
using InfoDisplay.Gui.ViewModels;

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
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _viewModel = DataContext as IWeatherViewModel;
            if (_viewModel == null)
            {
                throw new Exception("Missing IWeatherViewModel");
            }
            await _viewModel.GetWeatherAsync();
        }


        private IWeatherViewModel _viewModel;
    }
}
