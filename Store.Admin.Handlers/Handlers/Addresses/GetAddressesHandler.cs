using MediatR;
using Store.Admin.Handlers.Queries.Addresses;
using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Handlers.Addresses
{
    public class GetAddressesHandler : IRequestHandler<GetAddressesQuery, IApiResponse<IEnumerable<AddressModel>>>
    {
        private readonly IAddressRepository _addressRepository;
        public GetAddressesHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<IApiResponse<IEnumerable<AddressModel>>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetAllAsync();

            return ApiResponse<IEnumerable<AddressModel>>.Success(addresses.Select(x => x.Map()));
        }
    }
}
