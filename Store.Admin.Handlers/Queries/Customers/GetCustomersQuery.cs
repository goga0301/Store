using MediatR;
using Store.Domain.Entities;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Admin.Handlers.Queries.Customers
{
    public class GetCustomersQuery : IRequest<IApiResponse<IEnumerable<CustomerModel>>>
    {
    }
}
