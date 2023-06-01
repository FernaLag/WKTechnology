using WKTechnology.Core.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WKTechnology.Domain;
using WKTechnology.Persistence.Repositories;

namespace WKTechnology.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            string? mySqlConnection = configuration.GetConnectionString("WKTechnologyConnection");
            services.AddDbContextPool<WKTechnologyDbContext>(options =>
                options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            services.AddScoped<IGenericRepository<Categoria>, GenericRepository<Categoria>>();
            services.AddScoped<IGenericRepository<Produto>, GenericRepository<Produto>>();

            return services;
        }
    }
}