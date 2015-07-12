using System.Windows.Input;

namespace InfoDisplay.Gui.Command
{
    /// <summary>
    /// Defines an interface for when <see cref="ICommand.CanExecuteChanged"/> should be raised.
    /// </summary>
    public interface IRaiseCanExecuteChanged
    {
        void RaiseCanExecuteChanged();
    }
}