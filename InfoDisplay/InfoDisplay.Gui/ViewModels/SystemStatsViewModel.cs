using System;
using System.Linq;
using System.Management;
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
            TotalCpuUsage = await Task.Factory.StartNew(() => GetTotalCpuUsage());
        }

        private string GetTotalCpuUsage()
        {
            var searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            var cpuTimes = searcher.Get()
                .Cast<ManagementObject>()
                .Select(mo => new
                {
                    Name = mo["Name"],
                    Usage = mo["PercentProcessorTime"]
                }
                )
                .ToList();
            //The '_Total' value represents the average usage across all cores,
            //and is the best representation of overall CPU usage
            var query = cpuTimes.Where(x => x.Name.ToString() == "_Total").Select(x => x.Usage);
            var cpuUsage = query.SingleOrDefault();
            return cpuUsage.ToString();
        }

        #region Fields

        private string _totalCpuUsage;

        #endregion
    }

}