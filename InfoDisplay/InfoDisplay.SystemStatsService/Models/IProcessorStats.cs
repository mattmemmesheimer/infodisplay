using System;

namespace InfoDisplay.SystemStatsService.Models
{
    /// <summary>
    /// Defines an interface for processor statistics.
    /// </summary>
    public interface IProcessorStats
    {
        /// <summary>
        /// Total CPU usage.
        /// </summary>
        UInt64 TotalUsage { get; set; }
    }
}