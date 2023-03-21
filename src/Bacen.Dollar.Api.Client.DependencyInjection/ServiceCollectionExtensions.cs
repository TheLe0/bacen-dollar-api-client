using Bacen.Dollar.Api.Client.Common;
using Bacen.Dollar.Api.Client.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace Bacen.Dollar.Api.Client.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBacenDollarApiClient(this IServiceCollection services)
        {
            services.AddTransient<IBacenDollarHttpClient, BacenDollarHttpClient>();

            services.AddTransient<IBacenDollarClient>(x =>
                new BacenDollarClient(x.GetRequiredService<IBacenDollarHttpClient>()));

            return services;
        }

        public static IServiceCollection AddBacenDollarApiClient(this IServiceCollection services, string baseUrl)
        {
            services.AddTransient<IBacenDollarHttpClient>(_ =>
                new BacenDollarHttpClient(baseUrl));

            services.AddTransient<IBacenDollarClient>(x =>
                new BacenDollarClient(x.GetRequiredService<IBacenDollarHttpClient>()));

            return services;
        }

        public static IServiceCollection AddBacenDollarApiClient(this IServiceCollection services, BacenDollarClientConfiguration configs)
        {
            services.AddTransient<IBacenDollarHttpClient>(_ =>
                new BacenDollarHttpClient(configs));

            services.AddTransient<IBacenDollarClient>(x =>
                new BacenDollarClient(x.GetRequiredService<IBacenDollarHttpClient>()));

            return services;
        }
    }
}
