namespace RabbitMQ.Domains.Core.Events
{
    public abstract class Event
    {
        public DateTime Timestamp { get;  set; }

        public Event()
        {
            Timestamp = DateTime.Now;
        }

    }
}
