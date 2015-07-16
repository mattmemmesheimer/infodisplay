namespace InfoDisplay.SystemStatsService.Services
{
    /// <summary>
    /// Concrete implementation of <see cref="ISystemStatsService"/>.
    /// </summary>
    public class SystemStatsService : ISystemStatsService
    {
        /// <summary>
        /// Processor statistics.
        /// </summary>
        public IProcessorStatsService Processor { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="processorStatsService">Processor stats service to use.</param>
        public SystemStatsService(IProcessorStatsService processorStatsService)
        {
            Processor = processorStatsService;
        }
    }
}
