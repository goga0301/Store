using Store.Domain.Entities.Base;
using Store.Domain.Entities.Enums;

namespace Store.Domain.Entities
{
    public class Card : BaseEntity<int>
    {
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string CardholderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CvvCode { get; set; }
        public CardTypeEnum CardType { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
