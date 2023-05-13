using RabbitMQ.Domains.Core.Events;

namespace RabbitMQ.Domains.Core.Bus
{
    public  interface IEventHandler <in TEvent>: IEventHandler where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
