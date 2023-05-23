using RabbitMQ.Domains.Core.Events;
using Store.Domain.Entities.Enums;

namespace Store.Domain.Models.Domain
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int CardId { get; set; }
        public decimal Amount { get; set; }
        public TransactionStatusEnum Status { get; set; }
        public RecordStatusEnum RecordStatus { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreateUserId { get; set; }
    }

    public class CreateTransactionModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int CardId { get; set; }
        public decimal Amount { get; set; }
    }

    public class UpdateTransactionModel
    {
        public int Id { get; set; }
        public TransactionStatusEnum Status { get; set; }
    }

    public class CreateTransactionEvent : Event
    {

        public int ExternalId { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public CardModelForTransaction Card { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
    }

    public class TransactionResultEvent : Event
    {
        public int ExternalId { get; set; }
        public TransactionStatusEnum TransactionStatus { get; set; }
    }


}
