using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using InfoDisplay.Gui.Command;
using InfoDisplay.SystemStatsService;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.Gui.ViewModels
{
    /// <summary>
    /// Concrete implementation of <see cref="ISystemStatsViewModel"/>.
    /// </summary>
    public class SystemStatsViewModel : BindableBase, ISystemStatsViewModel
    {
        #region Constants

        private const uint ProcessorServiceRefreshIntervalMs = 25;

        #endregion

        #region Properties

        public double TotalCpuUsage
        {
            get { return _totalCpuUsage; }
            set { SetProperty(ref _totalCpuUsage, value); }
        }

        public ICommand RefreshCommand { get; private set; }

        #endregion

        public SystemStatsViewModel(ISystemStatsService systemStatsService)
        {
            _systemStatsService = systemStatsService;
            RefreshCommand = new DelegateCommand(Start);

            _processorServiceTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(ProcessorServiceRefreshIntervalMs)
            };
            _processorServiceTimer.Tick += ProcessorServiceTimerTick;
        }

        private void Start()
        {
            _processorServiceTimer.Start();
        }

        private async void ProcessorServiceTimerTick(object sender, EventArgs e)
        {
            await GetSystemStatsAsync();
        }

        private async Task GetSystemStatsAsync()
        {
            _processorServiceTimer.Stop();
            var stats = await _systemStatsService.Processor.GetStatsAsync();
            TotalCpuUsage = Convert.ToDouble(stats.TotalUsage);
            _processorServiceTimer.Start();
        }

        #region Fields

        private double _totalCpuUsage;
        private readonly ISystemStatsService _systemStatsService;
        private readonly DispatcherTimer _processorServiceTimer;

        #endregion
    }

}