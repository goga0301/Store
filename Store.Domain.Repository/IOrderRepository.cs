using Store.Domain.Entities;
using Store.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
