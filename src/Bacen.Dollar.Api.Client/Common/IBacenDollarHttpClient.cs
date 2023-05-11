using System.Threading.Tasks;
using RestSharp;

namespace Bacen.Dollar.Api.Client.Common
{
    public interface IBacenDollarHttpClient
    {
        string GetBaseUrl();
        Task<T> GetAsync<T>(RestRequest request);
    }
}
