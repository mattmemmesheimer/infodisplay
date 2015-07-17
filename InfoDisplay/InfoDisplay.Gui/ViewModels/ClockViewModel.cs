using System;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.Gui.ViewModels
{
    /// <summary>
    /// View model for a clock view.
    /// </summary>
    public class ClockViewModel : BindableBase
    {
        #region Constants

        private const int ClockRefreshIntervalMs = 1000;

        #endregion

        #region Properties

        /// <summary>
        /// Current timestamp.
        /// </summary>
        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { SetProperty(ref _timestamp, value); }
        }

        /// <summary>
        /// Command to start the clock.
        /// </summary>
        public ICommand StartCommand { get; private set; }

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        public ClockViewModel()
        {
            Timestamp = DateTime.Now;
            StartCommand = new DelegateCommand(Start);
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(ClockRefreshIntervalMs)
            };
            _timer.Tick += TimerTick;
        }

        /// <summary>
        /// Starts the clock.
        /// </summary>
        public void Start()
        {
            _timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Timestamp = DateTime.Now;
        }

        #region Fields

        private readonly DispatcherTimer _timer;
        private DateTime _timestamp;

        #endregion
    }
}
