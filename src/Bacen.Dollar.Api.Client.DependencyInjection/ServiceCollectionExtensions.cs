using Microsoft.Extensions.DependencyInjection;

namespace Bacen.Dollar.Api.Client.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBacenDollarApiClient(this IServiceCollection services)
        {
            return services;
        }
    }
}
