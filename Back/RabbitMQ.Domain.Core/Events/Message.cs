using MediatR;

namespace RabbitMQ.Domains.Core.Events
{
    public abstract class Message :IRequest<bool>
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
