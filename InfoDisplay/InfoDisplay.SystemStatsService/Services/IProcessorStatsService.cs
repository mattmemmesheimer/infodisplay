using System.Threading.Tasks;
using InfoDisplay.SystemStatsService.Models;

namespace InfoDisplay.SystemStatsService.Services
{
    /// <summary>
    /// Defines an interface for retrieving processor statistics.
    /// </summary>
    public interface IProcessorStatsService
    {
        /// <summary>
        /// Asynchronously retrieves processor statistics.
        /// </summary>
        /// <returns>Processor stats.</returns>
        Task<IProcessorStats> GetStatsAsync();
    }
}