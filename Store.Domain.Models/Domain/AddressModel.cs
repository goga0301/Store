using Store.Domain.Entities.Enums;

namespace Store.Domain.Models.Domain
{
    public class AddressModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string? Building { get; set; }
        public string? Floor { get; set; }
        public RecordStatusEnum RecordStatus { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string? CreateUserId { get; set; }
    }

    public class CreateAddressModel
    {
        public int CustomerId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string? Building { get; set; }
        public string? Floor { get; set; }
    }
    public class UpdateAddressModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string? Building { get; set; }
        public string? Floor { get; set; }
    }
    public class DeleteAddressModel
    {
        public int Id { get; set; }
    }
}
