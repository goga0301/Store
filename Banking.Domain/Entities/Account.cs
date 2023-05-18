using Banking.Domain.Entities.Base;

namespace Banking.Domain.Entities
{
    public class Account : BaseEntity<int>
    {

        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public virtual IEnumerable<Card> Cards { get; set; }

    }
}
