using Banking.Domain.Models.Models;
using RabbitMQ.Domains.Core.Bus;

namespace Banking.Handlers.Handlers
{
    public class CreateTransactionHandler : IEventHandler<CreateTransactionEvent>
    {
        public CreateTransactionHandler()
        {
                
        }
        public Task Handle(CreateTransactionEvent @event)
        {
            var t = @event;
            return Task.CompletedTask;
        }
    }
}
