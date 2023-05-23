using Banking.Infrastructure.Service.Domain;
using Banking.Domain.Service.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Infrastructure.Service
{
    public static class Extentions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();

        }
    }
}
