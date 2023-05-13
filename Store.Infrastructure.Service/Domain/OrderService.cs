using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Domain.Service.Domain;

namespace Store.Infrastructure.Service.Domain
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async void AddOrder(CreateOrderModel order)
        {
            _orderRepository.Create(order.Map());
            await _orderRepository.SaveChangesAsync();
        }

        public async void DeleteOrder(int Id)
        {
            var order = await _orderRepository.GetSingleAsync(x => x.Id == Id);
            if (order == null)
            {
                throw new Exception("შეკვეთა ვერ მოიძებნა");
            }

            _orderRepository.SoftDelete(order);
            await _orderRepository.SaveChangesAsync();
        }



        public async Task<OrderModel> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetSingleAsync(x => x.Id == id, k => k.Customer, k => k.Address);
            if (order == null)
            {
                throw new Exception("შეკვეთა ვერ მოიძებნა");
            }
            return order.Map();
        }

        public async void UpdateOrder(UpdateOrderModel orderUpdate)
        {
            var order = await _orderRepository.GetSingleAsync(x => x.Id == orderUpdate.Id);
            if (order == null)
            {
                throw new Exception("შეკვეთა ვერ მოიძებნა");
            }

            order.AddressId = orderUpdate.AddressId;
            order.OrderItems = orderUpdate.OrderItems;
            order.Amount = orderUpdate.OrderItems == null || orderUpdate.OrderItems.Count() == 0 ? 0 : orderUpdate.OrderItems.Sum(x => x.UnitPrice * x.Quantity);


            _orderRepository.Update(order);
            await _orderRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            return (await _orderRepository.GetAllAsync(k => k.Customer, k => k.Address)).Select(x => x.Map());
        }
    }
}
