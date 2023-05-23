using Banking.Domain.Models.Events;
using Banking.Handlers.Handlers;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Domains.Core.Bus;

namespace Banking.Handlers
{
    public static class Extenstions
    {
        public static void AddRabbitMQHandlers(this IServiceCollection services)
        {

            services.AddScoped<CreateTransactionHandler>();
            services.AddScoped<IEventHandler<CreateTransactionEvent>, CreateTransactionHandler>();

            services.AddScoped<ProccessTransactionHandler>();
            services.AddScoped<IEventHandler<ProccessTransactionEvent>, ProccessTransactionHandler>();
        }

        public static void SubscribeRabbitMQHandlers(this IEventBus eventBus)
        {
            eventBus.Subscribe<CreateTransactionEvent, CreateTransactionHandler>();
            eventBus.Subscribe<ProccessTransactionEvent, ProccessTransactionHandler>();
        }

    }
}
