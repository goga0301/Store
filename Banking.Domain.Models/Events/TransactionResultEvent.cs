using Banking.Domain.Entities.Enums;
using RabbitMQ.Domains.Core.Events;

namespace Banking.Domain.Models.Events
{
    public class TransactionResultEvent : Event
    {
        public int ExternalId { get; set; }
        public TransactionStatusEnum TransactionStatus { get; set; }
    }
}
