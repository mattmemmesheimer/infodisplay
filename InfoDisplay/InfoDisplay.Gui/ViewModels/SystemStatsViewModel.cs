using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using InfoDisplay.Gui.Command;
using InfoDisplay.SystemStatsService;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.Gui.ViewModels
{
    /// <summary>
    /// Concrete implementation of <see cref="ISystemStatsViewModel"/>.
    /// </summary>
    public class SystemStatsViewModel : BindableBase, ISystemStatsViewModel
    {
        #region Properties

        public string TotalCpuUsage
        {
            get { return _totalCpuUsage; }
            set { SetProperty(ref _totalCpuUsage, value); }
        }

        public ICommand RefreshCommand { get; private set; }

        #endregion

        public SystemStatsViewModel(ISystemStatsService systemStatsService)
        {
            _systemStatsService = systemStatsService;
            RefreshCommand = new AwaitableDelegateCommand(GetSystemStatsAsync);
        }

        public async Task GetSystemStatsAsync()
        {
            TotalCpuUsage = "Loading...";
            var stats = await _systemStatsService.Processor.GetStatsAsync();
            TotalCpuUsage = string.Format("{0}%", stats.TotalUsage);
        }

        #region Fields

        private string _totalCpuUsage;
        private readonly ISystemStatsService _systemStatsService;

        #endregion
    }

}