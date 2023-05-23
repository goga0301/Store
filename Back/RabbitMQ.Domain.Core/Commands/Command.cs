using RabbitMQ.Domains.Core.Events;

namespace RabbitMQ.Domains.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp   { get; protected set; }
        public Command()
        {
           Timestamp = DateTime.Now;
        }
    }
}
