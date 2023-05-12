using Store.Domain.Entities;
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
                RecordStatus = customer.RecordStatus,
                CreateDate = customer.CreateDate,
                CreateUserId = customer.CreateUserId
            };
        }

    }
}
