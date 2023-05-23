using MediatR;
using Store.Admin.Handlers.Commands.Addresses;
using Store.Domain.Repository;
using Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.Addresses
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, IApiResponse<bool>>
    {
        private readonly IAddressRepository _addressRepository;
        public DeleteAddressHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<IApiResponse<bool>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var address = await _addressRepository.GetAsync(x => x.Id == request.Model.Id);
                if (address == null)
                {
                    throw new Exception("მისამართი ვერ მოიძებნა");
                }
                _addressRepository.SoftDelete(address);
                scope.Complete();
                
                return ApiResponse<bool>.Success(true, "მისამართი წაიშალა");
            
            }

        }
    }
}
