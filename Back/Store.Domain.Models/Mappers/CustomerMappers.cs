using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using Store.Domain.Models.Domain;

namespace Store.Domain.Models.Mappers
{
    public static class CustomerMappers
    {
        public static CustomerModel Map(this Customer customer)
        {
            return new CustomerModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                UserName = customer.UserName,
                Password = customer.Password,
                Gender = customer.Gender,
                BirthDate = customer.BirthDate,
                Addresses = customer.Addresses?.Select(x => x.Map()),
                Cards = customer.Cards?.Select(x => x.Map()),
                Orders = customer.Orders?.Select(x => x.Map()),
                RecordStatus = customer.RecordStatus,
                CreateDate = customer.CreateDate,
                CreateUserId = customer.CreateUserId
            };
        }

        public static Customer Map(this CreateCustomerModel source)
        {
            return new Customer
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email,
                UserName = source.UserName,
                Password = source.Password,
                Gender = source.Gender,
                BirthDate = source.BirthDate,
                RecordStatus = RecordStatusEnum.Active,
                CreateDate = DateTime.Now,
                CreateUserId = "test"
            };
        }

        public static CustomerModelForOrder MapForOrder(this Customer source)
        {
            return new CustomerModelForOrder
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email
            };
        }

    }
}
