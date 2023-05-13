using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Repository;
using Store.Infrastructure.Repository.DbContexts;
using Store.Infrastructure.Repository.Repositories;
using Store.Infrastructure.Repository.Repositories.Base;
using Store.Shared.Helpers;

namespace Store.Infrastructure.Repository
{
    public static class Extentions
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var devartConfig = Devart.Data.Oracle.Entity.Configuration.OracleEntityProviderConfig.Instance;
            devartConfig.Workarounds.DisableQuoting = true;

            services.AddDbContext<StoreDbContext>(x => x.UseOracle(configuration.GetConnectionString("StoreDb")));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionString, ConnectionString>();
            services.AddSingleton<IDbConnectionProvider,  DbConnectionProvider>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IMainCategoryRepository, MainCategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            
        }

    }
}
