using MediatR;
using Store.Admin.Handlers.Queries.Addresses;
using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Handlers.Addresses
{
    public class GetAddressHandler : IRequestHandler<GetAddressQuery, IApiResponse<AddressModel>>
    {
        private readonly IAddressRepository _addressRepository;
        public GetAddressHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<IApiResponse<AddressModel>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetAsync(x => x.Id == request.Id);
            if (address == null)
            {
                throw new Exception("მისამართი ვერ მოიძებნა");
            }
            else
            {
                return ApiResponse<AddressModel>.Success(address.Map());
            }
        }
    }
}