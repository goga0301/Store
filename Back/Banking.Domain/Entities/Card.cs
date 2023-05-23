using Banking.Domain.Entities.Base;

namespace Banking.Domain.Entities
{
    public class Card : BaseEntity<int>
    {
        public string CardNumber { get; set; }
        public string CardholderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CvvCode { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

    }
}
