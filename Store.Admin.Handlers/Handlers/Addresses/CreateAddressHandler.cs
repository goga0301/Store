using MediatR;
using Store.Admin.Handlers.Commands.Addresses;
using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using Store.Domain.Repository;
using Store.Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.Addresses
{
    public class CreateAddressHandler : IRequestHandler<CreateAddressCommand, IApiResponse<int>>
    {
        private readonly IAddressRepository _addressRepository;
        public CreateAddressHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<IApiResponse<int>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var address = new Address
                {
                    StreetAddress = request.Model.StreetAddress,
                    City = request.Model.City,
                    StateOrProvince = request.Model.StateOrProvince,
                    PostalCode = request.Model.PostalCode,
                    Country = request.Model.Country,
                    Building = request.Model.Building,
                    Floor = request.Model.Floor,
                    CustomerId = request.Model.CustomerId,
                    RecordStatus = RecordStatusEnum.Active,
                    CreateDate = DateTime.UtcNow,
                    CreateUserId = "test"
                };
                _addressRepository.Create(address);
                await _addressRepository.SaveChangesAsync();
                scope.Complete();

                return ApiResponse<int>.Success(address.Id,"მისამართი წარმატებით შეიქმნა");

            }
            
        }
    }
}
