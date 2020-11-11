using Acme.Api.Extensions;
using Acme.Core.OperationHandlers.AcquirerOperationHandlers;
using Acme.Core.OperationHandlers.MerchantOperationHandlers;
using Acme.Core.Repositories;
using Acme.Core.Settings;
using Acme.Data.Repositories;
using Acme.Data.Repositories.Cache;
using Acme.Infrastructure.Cache;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Acme.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddRedis(_configuration)
                .AddControllers();

            // Settings
            services
                .AddSingleton(_configuration.GetSection("CacheSettings:Default").Get<CacheSettings>(options => options.BindNonPublicProperties = true));

            services
                .AddSingleton(_configuration.GetSection("CacheSettings:Merchant").Get<MerchantCacheSettings>(options => options.BindNonPublicProperties = true));

            // Infrastructure
            services.AddScoped<ICacheService, RedisCacheService>();

            // Data
            services.AddScoped<IAcquirerRepository, AcquirerRepository>();

            services.AddScoped<IMerchantRepository, MerchantRepository>();
            services.Decorate<IMerchantRepository, MerchantCacheRepository>();
            
            // Services 
            services.AddScoped<IGetAcquirerOperationHandler, GetAcquirerOperationHandler>();
            services.AddScoped<IGetMerchantOperationHandler, GetMerchantOperationHandler>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
