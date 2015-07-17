using System.Windows;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.Shell
{
    public class PrismAppShellViewModel : BindableBase
    {
        #region Properties

        public bool Fullscreen
        {
            get { return _fullscreen; }
            set
            {
                if (value)
                {
                    WindowState = WindowState.Maximized;
                    WindowStyle = WindowStyle.None;
                }
                else
                {
                    WindowState = WindowState.Normal;
                    WindowStyle = WindowStyle.SingleBorderWindow;
                }
                SetProperty(ref _fullscreen, value);
            }
        }

        public WindowStyle WindowStyle
        {
            get { return _windowStyle; }
            private set { SetProperty(ref _windowStyle, value); }
        }

        public WindowState WindowState
        {
            get { return _windowState; }
            private set { SetProperty(ref _windowState, value); }
        }

        #endregion

        public PrismAppShellViewModel()
        {
            Fullscreen = false;
        }

        #region Fields

        private WindowStyle _windowStyle;
        private WindowState _windowState;
        private bool _fullscreen;

        #endregion
    }
}
