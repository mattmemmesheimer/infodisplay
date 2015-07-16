using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using InfoDisplay.SystemStatsService.Models;

namespace InfoDisplay.SystemStatsService.Services
{
    /// <summary>
    /// Concrete implementation of <see cref="IProcessorStatsService"/>.
    /// </summary>
    public class ProcessorStatsService : IProcessorStatsService
    {
        /// <see cref="IProcessorStatsService.GetStatsAsync"/>
        public async Task<IProcessorStats> GetStatsAsync()
        {
            var usage = await Task.Factory.StartNew(() => GetTotalCpuUsage());
            return new ProcessorStats
            {
                TotalUsage = usage
            };
        }

        private UInt64 GetTotalCpuUsage()
        {
            var counter = new PerformanceCounter
            {
                CategoryName = "Processor",
                CounterName = "% Processor Time",
                InstanceName = "_Total"
            };
            counter.NextValue();
            Thread.Sleep(1000);
            return (UInt64)counter.NextValue();
        }
    }
}
