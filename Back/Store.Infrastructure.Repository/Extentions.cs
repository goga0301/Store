using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Repository;
using Store.Infrastructure.Repository.DbContexts;
using Store.Infrastructure.Repository.Repositories;
using Store.Infrastructure.Repository.Repositories.Base;
using Shared.Helpers;
using Store.Domain.Repository.Base;

namespace Store.Infrastructure.Repository
{
    public static class Extentions
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<StoreDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("StoreDb")));
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
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            
        }

        public static void AddCacheRepositories(this IServiceCollection services)
        {
            //services.AddScoped(typeof(GenericRepository<,,>));
        }

    }
}
