using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Queries.Customers
{
    public class GetCustomersQuery : IRequest<IApiResponse<IEnumerable<CustomerModel>>>
    {
    }
}
