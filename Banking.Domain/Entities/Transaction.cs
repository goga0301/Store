using Banking.Domain.Entities.Base;
using Banking.Domain.Entities.Enums;

namespace Banking.Domain.Entities
{
    public class Transaction : BaseEntity<int>
    {
        public int CardId { get; set; }
        public virtual Card Card { get; set; }
        public decimal Amount { get; set; }
        public int ExternalId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public TransactionStatusEnum TransactionStatus { get; set; }
    }
}
