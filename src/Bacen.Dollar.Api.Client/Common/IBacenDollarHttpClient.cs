using System.Threading.Tasks;

namespace Bacen.Dollar.Api.Client.Common
{
    public interface IBacenDollarHttpClient
    {
        string GetBaseUrl();
        Task<T> GetAsync<T>(string parameters);
    }
}
