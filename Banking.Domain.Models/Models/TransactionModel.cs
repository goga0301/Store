using Banking.Domain.Entities.Enums;

namespace Banking.Domain.Models.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public decimal Amount { get; set; }
        public int ExternalId { get; set; }
        public TransactionStatusEnum TransactionStatus { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public RecordStatusEnum RecordStatus { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreateUserId { get; set; }
    }

    public class CreateTransactionModel
    {
        public int CardId { get; set; }
        public decimal Amount { get; set; }
        public int ExternalId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
    }

    public class UpdateTransactionModel
    {
        public int Id { get; set; }
        public TransactionStatusEnum TransactionStatus { get; set; }
    }

    public class DeleteTransactionModel
    {
        public int Id { get; set; }
    }


}
