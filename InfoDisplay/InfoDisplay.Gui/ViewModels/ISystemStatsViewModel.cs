using System.Threading.Tasks;
using System.Windows.Input;

namespace InfoDisplay.Gui.ViewModels
{
    /// <summary>
    /// Defines an interface for the system stats view model.
    /// </summary>
    public interface ISystemStatsViewModel
    {
        Task GetSystemStatsAsync();

        ICommand RefreshCommand { get; }
    }
}