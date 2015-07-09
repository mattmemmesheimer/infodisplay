using InfoDisplay.Gui.ViewModels;
using Microsoft.Practices.Unity;

namespace InfoDisplay.Gui
{
    /// <summary>
    /// Interaction logic for InfoDisplayContainer.xaml
    /// </summary>
    public partial class InfoDisplayContainer
    {
        public InfoDisplayContainer(IUnityContainer container, InfoDisplayContainerViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
