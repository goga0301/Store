using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Queries.Addresses
{
    public class GetAddressQuery : IRequest<IApiResponse<AddressModel>>
    {
        public int Id { get; set; }
        public GetAddressQuery(int id)
        {
            Id = id;
        }
    }
}
