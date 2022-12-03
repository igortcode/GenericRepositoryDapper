using DapperGRP.Domain.Interfaces.Repository;
using DapperGRP.Domain.Settings;
using DapperGRP.Repository.Repository;

namespace DapperGRP.Api.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
            services.AddScoped<IProductRepository, ProductRepository>();


            return services;
        }
    }
}
