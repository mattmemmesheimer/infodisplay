using InfoDisplay.SystemStatsService.Services;

namespace InfoDisplay.SystemStatsService
{
    /// <summary>
    /// Defines an interface for a system statistics service.
    /// </summary>
    public interface ISystemStatsService
    {
        /// <summary>
        /// Processor statistics.
        /// </summary>
        IProcessorStatsService Processor { get; set; }
    }
}
