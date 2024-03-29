﻿using Store.Domain.Models.Domain;

namespace Store.Domain.Service.Domain
{
    public interface IOrderService
    {
        Task<int> AddOrder(CreateOrderModel order);
        void UpdateOrder(UpdateOrderModel order); 
        void DeleteOrder(int Id);
        Task<OrderModel> GetOrderByIdAsync(int Id);
        Task<IEnumerable<OrderModel>> GetAllOrders();
    }
}
