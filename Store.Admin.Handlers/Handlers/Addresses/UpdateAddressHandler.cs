using MediatR;
using Store.Admin.Handlers.Commands.Addresses;
using Store.Domain.Repository;
using Store.Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.Addresses
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand, IApiResponse<bool>>
    {
        private readonly IAddressRepository _addressRepository;
        public UpdateAddressHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<IApiResponse<bool>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var address = await _addressRepository.GetAsync(x => x.Id == request.Model.Id);
                if (address == null)
                {
                    throw new Exception("მისამართი ვერ მოიძებნა");
                }
                address.StreetAddress = request.Model.StreetAddress;
                address.City = request.Model.City;
                address.StateOrProvince = request.Model.StateOrProvince;
                address.PostalCode = request.Model.PostalCode;
                address.Country = request.Model.Country;
                address.Building = request.Model.Building;
                address.Floor = request.Model.Floor;
                _addressRepository.Update(address);
                await _addressRepository.SaveChangesAsync();
                scope.Complete();
                
                return ApiResponse<bool>.Success(true, "მისამართი განახლდა");
            }
        }
    }
}
