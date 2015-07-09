using System.Threading.Tasks;

namespace InfoDisplay.Common.Network
{

    public interface INetworkService
    {
        Task<string> GetStringAsync(string url);
    }

}