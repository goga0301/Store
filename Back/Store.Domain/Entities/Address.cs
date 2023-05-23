using Store.Domain.Entities.Base;

namespace Store.Domain.Entities
{
    public class Address : BaseEntity<int>
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string? Building { get; set; }
        public string? Floor { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
