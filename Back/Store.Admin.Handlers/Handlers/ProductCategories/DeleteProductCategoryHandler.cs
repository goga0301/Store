

using MediatR;
using Store.Admin.Handlers.Commands.ProductCategories;
using Store.Domain.Repository;
using Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.ProductsCategories
{
    public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryCommand, IApiResponse<bool>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public DeleteProductCategoryHandler(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IApiResponse<bool>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var item = await _productCategoryRepository.GetAsync(x => x.Id == request.Model.Id);
                if (item == null)
                {
                    throw new Exception("პროდუქტი ვერ მოიძებნა");
                }

                _productCategoryRepository.SoftDelete(item);

                await _productCategoryRepository.SaveChangesAsync();

                scope.Complete();
                return ApiResponse<bool>.Success(true, "პროდუქტი წარმატებით წაიშალა");
            }
        }
    }
}
