using Store.Domain.Entities;
using Store.Domain.Repository.Base;

namespace Store.Domain.Repository
{
    public interface IOrderRepository : IGenericRepository<Order, int>
    {
    }
}
