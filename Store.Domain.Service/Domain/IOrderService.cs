using Store.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Service.Domain
{
    public interface IOrderService
    {
        void AddOrder(CreateOrderModel order);
        void UpdateOrder(UpdateOrderModel order); 
        void DeleteOrder(int Id);
        Task<OrderModel> GetOrderByIdAsync(int Id);
        Task<IEnumerable<OrderModel>> GetAllOrders();
    }
}
