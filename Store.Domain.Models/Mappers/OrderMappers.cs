using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using Store.Domain.Models.Domain;

namespace Store.Domain.Models.Mappers
{
    public static class OrderMappers
    {
        public static Order Map(this CreateOrderModel source)
        {
            return new Order
            {
                CustomerId = source.CustomerId,
                AddressId = source.AddressId,
                IsPaid = false,
                TransactionId = null,
                OrderItems = source.OrderItems,
                Amount = source.OrderItems == null || source.OrderItems.Count() == 0 ? 0 : source.OrderItems.Sum(x => x.UnitPrice * x.Quantity),
                RecordStatus = RecordStatusEnum.Active,
                CreateDate = DateTimeOffset.Now,
                CreateUserId = "test"
            };
        }

        public static OrderModel Map(this Order source)
        {

            return new OrderModel
            {
                Id = source.Id,
                CustomerId = source.CustomerId,
                Customer = source.Customer.MapForOrder(),
                AddressId = source.AddressId,
                Address = source.Address.MapForOrder(),
                Amount = source.Amount,
                IsPaid = source.IsPaid,
                TransactionId = source.TransactionId,
                OrderItems = source.OrderItems,
            };

        }

    }
}
