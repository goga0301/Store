using Store.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public decimal Amount { get; set;  }
        public bool IsPaid { get; set; }
        public int? TransactionId { get; set; }
        public IEnumerable<OrderItem>? OrderItems { get; set; }

        public Order()
        {
            Amount = OrderItems == null || OrderItems.Count() == 0 ? 0 :  OrderItems.Sum(x => x.UnitPrice * x.Quantity);
        }
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
