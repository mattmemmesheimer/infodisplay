using System.Net;
using System.Threading.Tasks;

namespace InfoDisplay.Common.Network
{
    /// <summary>
    /// HTTP implementation of <see cref="INetworkService"/>.
    /// </summary>
    public class HttpNetworkService : INetworkService
    {
        /// <see cref="INetworkService.GetStringAsync"/>
        public async Task<string> GetStringAsync(string url)
        {
            var client = new WebClient();
            return await client.DownloadStringTaskAsync(url);
        }
    }

}