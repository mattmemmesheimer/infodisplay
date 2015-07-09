using System.Net;
using System.Threading.Tasks;

namespace InfoDisplay.Common.Network
{

    public class HttpNetworkService : INetworkService
    {
        public async Task<string> GetStringAsync(string url)
        {
            var client = new WebClient();
            return await client.DownloadStringTaskAsync(url);
        }
    }

}