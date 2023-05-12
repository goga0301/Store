

using MediatR;
using Store.Admin.Handlers.Commands.Products;
using Store.Domain.Repository;
using Store.Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, IApiResponse<bool>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IApiResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var item = await _productRepository.GetAsync(x => x.Id == request.Model.Id);
                if (item == null)
                {
                    throw new Exception("პროდუქტი ვერ მოიძებნა");
                }

                _productRepository.SoftDelete(item);

                await _productRepository.SaveChangesAsync();

                scope.Complete();
                return ApiResponse<bool>.Success(true, "პროდუქტი წარმატებით წაიშალა");
            }
        }
    }
}
