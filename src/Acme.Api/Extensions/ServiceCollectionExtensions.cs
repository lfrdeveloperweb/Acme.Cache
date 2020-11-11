using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acme.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// This method configures the distributed cache with redis.
        /// </summary>
        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "Aditum.Cache";
            });

            return services;
        }
    }
}
