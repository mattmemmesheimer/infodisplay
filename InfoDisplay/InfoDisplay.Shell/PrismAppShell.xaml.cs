using System.Windows.Input;

namespace InfoDisplay.Shell
{
    /// <summary>
    /// Interaction logic for PrismAppShell.xaml
    /// </summary>
    public partial class PrismAppShell
    {
        public PrismAppShell()
        {
            _viewModel = new PrismAppShellViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void Window_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F11)
            {
                _viewModel.Fullscreen = !_viewModel.Fullscreen;
            }
            if (e.Key == Key.Escape && _viewModel.Fullscreen)
            {
                _viewModel.Fullscreen = false;
            }
        }

        private readonly PrismAppShellViewModel _viewModel;
    }
}
