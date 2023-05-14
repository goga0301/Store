using Store.Domain.Entities.Base;
using Store.Domain.Entities.Enums;

namespace Store.Domain.Entities
{
    public class Transaction : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int CardId { get; set; }
        public decimal Amount { get; set; }
        public TransactionStatusEnum Status { get; set; }
    }
}
