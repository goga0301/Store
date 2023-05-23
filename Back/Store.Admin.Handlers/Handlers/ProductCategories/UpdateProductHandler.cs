using MediatR;
using Store.Admin.Handlers.Commands.ProductCategories;
using Store.Domain.Repository;
using Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.ProductCategories
{
    public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand, IApiResponse<bool>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public UpdateProductCategoryHandler(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task<IApiResponse<bool>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var item = await _productCategoryRepository.GetAsync(x => x.Id == request.Model.Id);
                if (item == null)
                {
                    throw new Exception("პროდუქტი ვერ მოიძებნა");
                }
                item.Name = request.Model.Name;
                item.Description = request.Model.Description;
                item.MainCategoryId = request.Model.MainCategoryId;

                _productCategoryRepository.Update(item);
                await _productCategoryRepository.SaveChangesAsync();
                scope.Complete();
                return ApiResponse<bool>.Success(true, "პროდუქტი წარმატებით განახლდა");
            }


        }
    }
}
