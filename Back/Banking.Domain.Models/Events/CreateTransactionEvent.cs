using RabbitMQ.Domains.Core.Events;

namespace Banking.Domain.Models.Events
{
    public class CreateTransactionEvent : Event
    {
        public CardModelForTransaction Card { get; set; }
        public decimal Amount { get; set; }
        public int ExternalId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }

    }

    public class CardModelForTransaction
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardholderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CvvCode { get; set; }
    }
}
