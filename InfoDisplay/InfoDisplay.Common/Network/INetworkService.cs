using System.Threading.Tasks;

namespace InfoDisplay.Common.Network
{
    /// <summary>
    /// Network service interface.
    /// </summary>
    public interface INetworkService
    {
        /// <summary>
        /// Asynchronously downloads a string from the specified URL.
        /// </summary>
        /// <param name="url">URL to download from.</param>
        /// <returns>Downloaded string.</returns>
        Task<string> GetStringAsync(string url);
    }
}