using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using InfoDisplay.Gui.Command;
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

        public SystemStatsViewModel()
        {
            RefreshCommand = new AwaitableDelegateCommand(GetSystemStatsAsync);
        }

        public async Task GetSystemStatsAsync()
        {
            TotalCpuUsage = "Loading...";
            var usage = await Task.Factory.StartNew(() => GetTotalCpuUsage());
            TotalCpuUsage = string.Format("{0}%", usage);
        }

        public UInt64 GetTotalCpuUsage()
        {
            var counter = new PerformanceCounter
            {
                CategoryName = "Processor",
                CounterName = "% Processor Time",
                InstanceName = "_Total"
            };
            counter.NextValue();
            Thread.Sleep(1000);
            return (UInt64) counter.NextValue();
        }

        #region Fields

        private string _totalCpuUsage;

        #endregion
    }

}