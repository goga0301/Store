using Store.Domain.Entities;
using Store.Domain.Entities.Enums;

namespace Store.Domain.Models.Domain
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerModelForOrder Customer { get; set; }
        public int AddressId { get; set; }
        public virtual AddressModelForOrder Address { get; set; }
        public OrderStatusEnum Status { get; set; }
        public decimal Amount { get; set; }
        public int? TransactionId { get; set; }
        public IEnumerable<OrderItem>? OrderItems { get; set; }
    }

    public class CreateOrderModel
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public IEnumerable<OrderItem>? OrderItems { get; set; }
    }

    public class UpdateOrderModel
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public OrderStatusEnum Status { get; set; }
        public IEnumerable<OrderItem>? OrderItems { get; set; }
    }

    
}
