using MediatR;
using Store.Admin.Handlers.Commands.ProductCategories;
using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using Store.Domain.Repository;
using Store.Shared.Helpers;
using System.Transactions;

namespace Store.Admin.Handlers.Handlers.ProductsCategories
{
    public class CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryCommand, IApiResponse<int>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public CreateProductCategoryHandler(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task<IApiResponse<int>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var productCategory = new ProductCategory
                {
                    Name = request.Model.Name,
                    Description = request.Model.Description,
                    MainCategoryId = request.Model.MainCategoryId,
                    RecordStatus = RecordStatusEnum.Active,
                    CreateDate = DateTime.Now,
                    CreateUserId = "test"

                };
                _productCategoryRepository.Create(productCategory);
                await _productCategoryRepository.SaveChangesAsync();
                scope.Complete();
                return ApiResponse<int>.Success(productCategory.Id, "პროდუქტი წარმატებით შეიქმნა");
            }
        }
    }
}
