using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Domains.Core.Bus;
using RabbitMQ.Infrastructure.Bus;
using Store.Shared.Helpers;

namespace Store.Shared
{
    public static class Extentions
    {
        public static void AddHelperServices(IServiceCollection services)
        {
            services.AddSingleton<IConnectionString, ConnectionString>();
        }

        public static void AddRabbitMQServices(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });
        }


    }
}
