using MediatR;
using Store.Domain.Models.Domain;
using Shared.Helpers;

namespace Store.Admin.Handlers.Queries.Customers
{
    public class GetCustomerQuery : IRequest<IApiResponse<CustomerModel>>
    {
        public int Id { get; set; }
        public GetCustomerQuery(int id)
        {
            Id = id;
        }
    }
}
