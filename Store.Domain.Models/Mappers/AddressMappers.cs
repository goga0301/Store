using Store.Domain.Entities;
using Store.Domain.Models.Domain;

namespace Store.Domain.Models.Mappers
{
    public static class AddressMappers
    {
        public static AddressModel Map(this Address source)
        {
            return new AddressModel
            {
                Id = source.Id,
                CustomerId = source.CustomerId,
                StreetAddress = source.StreetAddress,
                City = source.City,
                StateOrProvince = source.StateOrProvince,
                PostalCode = source.PostalCode,
                Country = source.Country,
                Building = source.Building,
                Floor = source.Floor,
                RecordStatus = source.RecordStatus,
                CreateDate = source.CreateDate,
                CreateUserId = source.CreateUserId
            };
        }
    }
}
