using Banking.Domain.Repository;
using Banking.Infrastructure.Repository.DbContexts;
using Banking.Infrastructure.Repository.Repositories;
using Banking.Infrastructure.Repository.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Helpers;

namespace Banking.Infrastructure.Repository
{
    public static  class Extensions
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var devartConfig = Devart.Data.Oracle.Entity.Configuration.OracleEntityProviderConfig.Instance;
            devartConfig.Workarounds.DisableQuoting = true;

            services.AddDbContext<BankingDbContext>(x => x.UseOracle(configuration.GetConnectionString("StoreDb")));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionString, ConnectionString>();
            services.AddSingleton<IDbConnectionProvider, DbConnectionProvider>();

            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

        }
    }
}
