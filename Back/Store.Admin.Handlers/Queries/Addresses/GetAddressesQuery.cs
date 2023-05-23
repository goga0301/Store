using MediatR;
using Store.Domain.Models.Domain;
using Shared.Helpers;

namespace Store.Admin.Handlers.Queries.Addresses
{
    public class GetAddressesQuery : IRequest<IApiResponse<IEnumerable<AddressModel>>>
    {
    }
}
