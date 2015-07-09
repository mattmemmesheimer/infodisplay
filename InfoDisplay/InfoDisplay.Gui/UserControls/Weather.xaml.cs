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
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as IWeatherViewModel;
            if (viewModel != null)
            {
                await viewModel.GetWeatherAsync();
            }      
        }
    }
}
