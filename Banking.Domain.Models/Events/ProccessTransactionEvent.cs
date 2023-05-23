using RabbitMQ.Domains.Core.Events;

namespace Banking.Domain.Models.Events
{
    public class ProccessTransactionEvent : Event
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
    }
}
